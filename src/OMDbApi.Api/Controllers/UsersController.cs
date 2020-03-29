using Microsoft.AspNetCore.Mvc;
using OMDbApi.Api.Contracts;
using OMDbApi.Api.Models;
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
            _usersRepository = usersRepository;
            _moviesRepository = movieRepository;
            _ratingsRepository = ratingsRepository;
            _transactionRepository = transactionRepository;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var result = _usersRepository.GetAll()
                .OrderBy(c => c.FirstName);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _usersRepository.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task PostUser(User user)
        {
            await _usersRepository.Add(user);
        }

        [HttpPost]
        [Route("add")]
        public async Task PostMovie([FromQuery] int id, [FromQuery] string title)
        {
            var user = await _usersRepository.GetById(id);
            var movie = await _moviesRepository.Find(title);
            var rating = new Rating()
            {
                UserId = user.UserId,
                IMDbId = movie.IMDbId
            };
            
            if (_moviesRepository.DoesExist(movie))
                return;

            await _transactionRepository
                .Transact(_usersRepository, _moviesRepository, user, movie, rating);
        }

        [HttpPost]
        [Route("rate")]
        public async Task RateMovie([FromQuery] int id, [FromQuery] string title, [FromQuery] int rating)
        {
            var user = await _usersRepository.GetById(id);
            var movie = await _moviesRepository.Find(title);
            var movieRating = await _ratingsRepository.Get(id, title);
            movieRating.MovieRating = rating;

            await _transactionRepository
                .Transact(_usersRepository, _moviesRepository, _ratingsRepository, user, movie, movieRating);
        }
        
        [HttpPut]
        [Route("update")]
        public async Task UpdateUser([FromQuery] int id, User user)
        {
            var entity = await _usersRepository.GetById(id);
            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            await _usersRepository.Update(entity);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task Remove(int id)
        {
            await _usersRepository.Remove(id);
        }
    }
}
