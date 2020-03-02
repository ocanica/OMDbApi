using OMDbApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OMDbApi.Api.Services
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly Task<Movie> _movieContext;
        private readonly JsonContentSerialiser _jsonContentSerialiser;

        public MoviesRepository(IHttpClientFactory httpClientFactory, JsonContentSerialiser jsonContentSerialiser)
        {
            _httpClientFactory = httpClientFactory;
            _jsonContentSerialiser = jsonContentSerialiser;
            //_movieContext = _jsonContentSerialiser.DeserialiseAsync<>
        }

        public async Task<Movie> DeserialiseJsonAsync()
        {
            var client = _httpClientFactory.CreateClient("OMDb");
            var response = await client.GetStringAsync("");
            return JsonSerializer.
        }

        public async Task<Movie> Get_MovieAsync(string title)
        {
            var repo = await _movieContext;
            if (String.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));

            return await 
        }
    }
}
