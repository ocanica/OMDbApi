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
        private readonly Constants _constants;

        public MoviesRepository(OMDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
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

        public async Task<Movie> Find(object id)
        {
            var configData = await _constants.omdbConfigData;
            var client = _httpClientFactory.CreateClient();
            var response = await client
                .GetStringAsync($"{configData.BaseUrl}?apikey={configData.ApiKey}&t={id.ToString()}");
            return JsonSerializer.Deserialize<Movie>(response);
        }
        public Task Rate(int id, string imdbId, int rating)
        {
            /*var user = await _usersRepository.GetById(id);
            var movie = await GetById(imdbId);
            var transact = _transactionsRepository.Transact(user.UserId, movie.IMDbId);

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {

                }
            }*/
            throw new NotImplementedException();
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

        public void Update(Movie entity)
        {
            throw new NotImplementedException();
        }

        public bool DoesExist(Movie enity)
        {
            if (_context.Movies.Any(c => c.IMDbId == enity.IMDbId))
                return true;
            return false;
        }

        public Task Add(int id, string title)
        {
            throw new NotImplementedException();
        }
    }
}
