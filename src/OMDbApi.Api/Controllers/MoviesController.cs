using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using OMDbApi.Api.Contracts;
using OMDbApi.Api.Models;
using System.Linq;

namespace OMDbApi.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesRepository _moviesRepository;

        public MoviesController(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        //Get: api/Movies
        [HttpGet]
        public IActionResult GetMovies()
        {
            var result = _moviesRepository.GetAll()
                .OrderBy(c => c.Title);
            return Ok(result);
        }

        //Get: api/Movies/Ghostbusters
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMovie(string id)
        {
            var result = await _moviesRepository.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("add/{id}")]
        public async Task AddMovie(string id)
        {
            var movie = await _moviesRepository.Find(id);
            await _moviesRepository.Add(movie);
        }
    }
}
