using Microsoft.AspNetCore.Mvc;
using OMDbApi.Api.Services;
using System.Net.Http;

namespace OMDbApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesContoller : ControllerBase
    {
        
        private readonly IMoviesRepository _moviesRepository;

        public MoviesContoller(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }
    }
}
