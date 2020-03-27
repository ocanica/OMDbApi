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

        [HttpPost]
        [Route("add")]
        public async Task Add()
        {
            var jamie = new User
            {
                Username = "jamiefox",
                Password = "InLivingColor93",
                FirstName = "Jamie",
                LastName = "Fox",
                DateRegistered = DateTime.Now,
                DateModified = DateTime.Now
            };

            var axel = new User
            {
                Username = "axelf",
                Password = "abc123",
                Email = "axelf@hotmail.com",
                FirstName = "Axel",
                LastName = "Foley",
                DateRegistered = DateTime.Now,
                DateModified = DateTime.Now
            };

            var hillary = new User
            {
                Username = "hillaryB",
                Password = "$$$$$",
                Email = "hillaryb@gmail.com",
                FirstName = "Hillary",
                LastName = "Banks",
                DateRegistered = DateTime.Now,
                DateModified = DateTime.Now
            };

            await _usersRepository.Add(jamie);
            await _usersRepository.Add(axel);
            await _usersRepository.Add(hillary);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _usersRepository.GetAll()
                .OrderBy(c => c.FirstName);
            return Ok(result);
        }

        [HttpPost]
        [Route("addmovie/{username}/{title}")]
        public async Task AddMovie(string username, string title)
        {
            await _moviesRepository.Add(username, title);
        } 

        [HttpGet]
        [Route("get/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var result = await _usersRepository.GetById(name);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Route("remove/{id}")]
        public async Task Remove(string id)
        {
            await _usersRepository.Remove(id);
        }
    }
}
