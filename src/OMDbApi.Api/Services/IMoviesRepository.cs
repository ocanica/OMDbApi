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
        Task<Movie> Get_MovieAsync(string title);
    }
}
