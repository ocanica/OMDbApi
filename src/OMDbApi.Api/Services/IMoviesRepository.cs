using OMDbApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OMDbApi.Api.Services
{
    public interface IMoviesRepository
    {
        public Task<IEnumerable<Movie>> GetMoviesAsync();
        public Task<Movie> GetMovieAsync(string title);
    }
}
