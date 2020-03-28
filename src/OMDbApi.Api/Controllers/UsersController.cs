using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [Route("addmovie/{userId}/{title}")]
        public async Task AddMovie(int id, string title)
        {
            await _moviesRepository.Add(id, title);
        } 

        [HttpDelete]
        [Route("{id}")]
        public async Task Remove(string id)
        {
            await _usersRepository.Remove(id);
        }
    }
}
