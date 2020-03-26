using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using OMDbApi.Api.Contracts;
using OMDbApi.Api.Models;

namespace OMDbApi.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IGenericRepository<Movie> _moviesRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly Constants _constants;

        public MoviesController(IGenericRepository<Movie> moviesRepository, IHttpClientFactory httpClientFactory)
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
        [Route("{id}")]
        public async Task<Movie> GetMovie(string id)
        {
            var configData = await _constants.omdbConfigData;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync($"{configData.BaseUrl}?apikey={configData.ApiKey}&t={id}");
            return JsonSerializer.Deserialize<Movie>(response);
        }

        [HttpPost]
        [Route("add/{id}")]
        public async Task AddMovie(string id)
        {
            var movie = await GetMovie(id);
            await _moviesRepository.Add(movie);
        }

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
