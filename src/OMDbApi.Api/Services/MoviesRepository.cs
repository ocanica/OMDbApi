using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OMDbApi.Api.Contracts;
using OMDbApi.Api.Data;
using OMDbApi.Api.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OMDbApi.Api.Services
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly OMDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUsersRepository _usersRepository;
        private readonly ITransactionRepository _transactionsRepository;
        private readonly Constants _constants;

        public MoviesRepository(
            OMDbContext context, IHttpClientFactory httpClientFactory,
            IUsersRepository usersRepository, ITransactionRepository transactionsRepository)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
            _usersRepository = usersRepository;
            _transactionsRepository = transactionsRepository;
            _constants = new Constants();
        }

        public IQueryable<Movie> GetAll()
        {
            return _context.Set<Movie>().AsNoTracking();
        }

        public async Task<Movie> GetById(object id)
        {
            var movie = _context.Movies;
            var result = await movie
                .FirstOrDefaultAsync(m => m.IMDbId == id.ToString());

            if (result == null)
                throw new ArgumentException($"No record of {id} can be found. Ensure IMDb ID is correct", nameof(id));

            return result;
        }

        public async Task Add(Movie entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        // User adds movie by creating a transaction
        public async Task Add(int id, string title)
        {
            var user = await _usersRepository.GetById(id);
            var movie = await Find(title);
            var rating = new Rating()
            {
                UserId = user.UserId,
                IMDbId = movie.IMDbId
            };
            var omdbTransaction = new Transaction
            {
                Username = user.Username,
                IMDbId = movie.IMDbId
            };

            // If the movie already exists, exit
            if (_context.Movies.Any(c => c.IMDbId == movie.IMDbId))
                return;

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await Add(movie);
                    await _context.AddAsync(rating);
                    await _transactionsRepository.Add(omdbTransaction);
                    await _usersRepository.Update(user);
                    await _context.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (DbUpdateException  e)
                {
                    // var sqlException = e.GetBaseException();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    throw;
                }
            }
        }

        public async Task<Movie> Find(object id)
        {
            var configData = await _constants.omdbConfigData;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync($"{configData.BaseUrl}?apikey={configData.ApiKey}&t={id.ToString()}");
            return JsonSerializer.Deserialize<Movie>(response);
        }

        public async Task Remove(object id)
        {
            var entity = await GetById(id);
            _context.RemoveRange(entity);
            await _context.SaveChangesAsync();
        }

        // Change entity state
        public async Task Save(Movie entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public Task Update(Movie entity)
        {
            throw new NotImplementedException();
        }

        public Task Rate(int rating)
        {
            throw new NotImplementedException();
        }
    }
}
