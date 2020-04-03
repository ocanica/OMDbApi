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

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> FindMovie([FromQuery]string q)
        {
            var movies = await _moviesRepository.ReturnTitles(q);
            return Ok(movies);
        }

        // POST api/[controller]/Batman
        [HttpPost]
        [Route("{title}")]
        public async Task AddMovie(string title)
        {
            var movie = await _moviesRepository.ReturnTitle(title);
            await _moviesRepository.Add(movie);
        }

    }
}
