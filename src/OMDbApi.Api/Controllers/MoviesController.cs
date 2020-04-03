using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using OMDbApi.Api.Contracts;
using OMDbApi.Api.Models;
using System.Linq;
using System;

namespace OMDbApi.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesRepository _moviesRepository;

        public MoviesController(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository
                ?? throw new ArgumentNullException(nameof(moviesRepository));
        }

        // GET api/[controller]
        [HttpGet]
        public IActionResult GetMovies()
        {
            var result = _moviesRepository.GetAll()
                .OrderBy(c => c.Title);
            return Ok(result);
        }

        // GET api/[controller]/tt0062622
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMovie(string id)
        {
            var result = await _moviesRepository.GetById(id);
            return Ok(result);
        }

        // POST api/[controller]/add/tt0062622
        [HttpPost]
        [Route("add/{id}")]
        public async Task AddMovie(string id)
        {
            var movie = await _moviesRepository.Find(id);
            await _moviesRepository.Add(movie);
        }
    }
}
