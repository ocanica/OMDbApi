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

        public UsersController(IUsersRepository usersRepository, IMoviesRepository movieRepository)
        {
            _usersRepository = usersRepository;
            _moviesRepository = movieRepository;
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
        public async Task AddMovie([FromQuery] int id, [FromQuery] string title)
        {
            await _moviesRepository.Add(id, title);
        }

        [HttpPost]
        [Route("rate")]
        public async Task RateMovie([FromQuery] int id, [FromQuery] int rating)
        {

        }
        
        [HttpPut]
        [Route("update")]
        public async Task UpdateUser([FromQuery] int id, User user)
        {
            /*var entity = await _usersRepository.GetById(id);
            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            await _usersRepository.Update(entity);*/
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task Remove(int id)
        {
            await _usersRepository.Remove(id);
        }
    }
}
