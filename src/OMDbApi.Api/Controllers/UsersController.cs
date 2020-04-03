using Microsoft.AspNetCore.Mvc;
using OMDbApi.Api.Contracts;
using OMDbApi.Api.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OMDbApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMoviesRepository _moviesRepository;
        private readonly IRatingsRepository _ratingsRepository;
        private readonly ITransactionRepository _transactionRepository;

        public UsersController(IUsersRepository usersRepository, IMoviesRepository movieRepository, 
            IRatingsRepository ratingsRepository, ITransactionRepository transactionRepository)
        {
            _usersRepository = usersRepository
                ?? throw new ArgumentNullException(nameof(usersRepository));
            _moviesRepository = movieRepository
                ?? throw new ArgumentNullException(nameof(movieRepository));
            _ratingsRepository = ratingsRepository
                ?? throw new ArgumentNullException(nameof(ratingsRepository));
            _transactionRepository = transactionRepository
                ?? throw new ArgumentNullException(nameof(transactionRepository));
        }

        // GET api/[controller]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var result = _usersRepository.GetAll()
                .OrderBy(c => c.FirstName);
            return Ok(result);
        }

        // GET api/[controller]/2
        /*[HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _usersRepository.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }*/

        // GET api/[controller]/carlton
        [HttpGet]
        [Route("{username}")]
        public async Task<IActionResult> GetByUser(string username)
        {
            var result = await _usersRepository.GetByUsername(username);
            return Ok(result);
        }

        // POST api/[controller]
        [HttpPost]
        public async Task PostUser([FromBody] User user)
        {
            await _usersRepository.Add(user);
        }

        // POST api/[controller]/add[?id=2&title=batman]
        [HttpPost]
        [Route("add")]
        public async Task PostMovie([FromQuery] int id, [FromQuery] string title)
        {
            var user = await _usersRepository.GetById(id);
            var movie = await _moviesRepository.Find(title);

            await _transactionRepository
                .Transact(_usersRepository, _moviesRepository, user, movie);
        }

        // PUT api/[controller]/rate[?id=2&title=batman&rating=7]
        [HttpPut]
        [Route("rate")]
        public async Task RateMovie([FromQuery] int id, [FromQuery] string title, [FromQuery] int rating)
        {
            var user = await _usersRepository.GetById(id);
            var movie = await _moviesRepository.Find(title);
            var movieRating = _ratingsRepository.CreateRating(user.UserId, movie.IMDbId);
            movieRating.MovieRating = rating;

            await _transactionRepository
                .Transact(_usersRepository, _moviesRepository, _ratingsRepository, user, movie, movieRating);
        }
        
        // PUT api/[controller]/update[?id=2]
        [HttpPut]
        [Route("update")]
        public async Task UpdateUser([FromQuery] int id, [FromBody] User user)
        {
            var entity = await _usersRepository.GetById(id);
            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            _usersRepository.Update(entity);
        }

        // DELETE api/[controller]/remove/2
        [HttpDelete]
        [Route("{id}")]
        public async Task Remove(int id)
        {
            await _usersRepository.Remove(id);
        }

        [HttpGet]
        [Route("{username}/movies")]
        public IActionResult GetMovies(string username)
        {
            return Ok(_usersRepository.ReturnUserMovies(username));
        }
    }
}
