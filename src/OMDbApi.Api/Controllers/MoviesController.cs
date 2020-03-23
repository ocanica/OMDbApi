﻿using Microsoft.AspNetCore.Mvc;
using OMDbApi.Api.Services;
using OMDbApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OMDbApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly IHttpClientFactory _httpClientFactory;

        public MoviesController(IMoviesRepository moviesRepository, IHttpClientFactory httpClientFactory)
        {
            _moviesRepository = moviesRepository;
            _httpClientFactory = httpClientFactory;
        }

        //Get: api/Movies
        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync("http://www.omdbapi.com/?apikey=75f14f13&t=batman");
            return Ok(JsonSerializer.Deserialize<Movie>(response));
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

        // Get: api/Movies/Ghostbusters
        /*[HttpGet]
        [Route("{title}")]
        public async Task<IActionResult> GetMovie(string title)
        {
            var result = await _moviesRepository.GetMovieAsync(title);
            if (result == null)
                return NotFound();

            return Ok(result);
        }*/

        //Post: api/Movie/
    }
}
