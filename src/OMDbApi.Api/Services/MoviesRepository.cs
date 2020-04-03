using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
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
            _context = context 
                ?? throw new ArgumentNullException(nameof(context));
            _httpClientFactory = httpClientFactory
                ?? throw new ArgumentNullException(nameof(httpClientFactory));
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
            if (DoesExist(entity))
                return;
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> ReturnTitle(string title)
        {
            var configData = await _constants.omdbConfigData;
            var client = _httpClientFactory.CreateClient();
            var response = await client
                .GetStringAsync($"{configData.BaseUrl}?apikey={configData.ApiKey}&t={title.ToString()}");
            return JsonSerializer.Deserialize<Movie>(response);
        }

        public async Task<IEnumerable<MovieMinified>> ReturnTitles(string title)
        {
            var configData = await _constants.omdbConfigData;
            var client = _httpClientFactory.CreateClient();
            var response = await client
                .GetStringAsync($"{configData.BaseUrl}?apikey={configData.ApiKey}&s={title.ToString()}&type=movie");
            // Need to research JObject implementation in Text.Json;
            var jsonDocument = JObject.Parse(response).SelectToken("Search").ToString();
            return JsonSerializer.Deserialize<IEnumerable<MovieMinified>>(jsonDocument);
        }

        public async Task Remove(object id)
        {
            var entity = await GetById(id);
            _context.RemoveRange(entity);
            await _context.SaveChangesAsync();
        }

        // Change entity state
        /*public async Task Save(Movie entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }*/

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

        public Task Save(Movie entity)
        {
            throw new NotImplementedException();
        }
    }
}
