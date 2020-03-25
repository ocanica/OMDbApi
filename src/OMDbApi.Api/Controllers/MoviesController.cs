using Microsoft.AspNetCore.Mvc;
using OMDbApi.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using OMDbApi.Contracts;

namespace OMDbApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly Constants _constants;

        public MoviesController(IMoviesRepository moviesRepository, IHttpClientFactory httpClientFactory)
        {
            _moviesRepository = moviesRepository;
            _httpClientFactory = httpClientFactory;
            _constants = new Constants();
        }

        //Get: api/Movies
        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var configData = await _constants.omdbConfigData;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync($"{configData.BaseUrl}?apikey={configData.ApiKey}&t=batman");
            return Ok(JsonSerializer.Deserialize<Movie>(response));
        }

        //Get: api/Movie/Ghostbusters
        [HttpGet]
        [Route("{title}")]
        public async Task<IActionResult> GetMovie(string title)
        {
            var configData = await _constants.omdbConfigData;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync($"{configData.BaseUrl}?apikey={configData.ApiKey}&t={title}");
            return Ok(JsonSerializer.Deserialize<Movie>(response));
        }

        // Get: api/Movies/id
        /*[HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMovie(string id)
        {
            var result = await _moviesRepository.GetMovieAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }*/

        //Get: api/Movie
        /*[HttpGet]

        public async Task<IActionResult> GetMovie()
        {
            var client = _httpClientFactory.CreateClient("OMDb");
            var response = await client.GetStringAsync("");
            return Ok(JsonSerializer.Deserialize<Movie>(response));
        }*/

        //Get: api/Movies
        /*[HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var result = await _moviesRepository.GetMoviesAsync();
            if (result == null)
                return NotFound();

            return Ok(result);
        }*/



        //Post: api/Movie/
    }
}
