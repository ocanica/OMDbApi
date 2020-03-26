using Microsoft.AspNetCore.Mvc;
using OMDbApi.Api.Contracts;
using OMDbApi.Api.Models;
using System;
using System.Threading.Tasks;

namespace OMDbApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IGenericRepository<User> _usersRepository;

        public UsersController(IGenericRepository<User> usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _usersRepository.GetAll();
            return Ok(result);
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

            await _usersRepository.Add(jamie);
            await _usersRepository.Add(axel);
        }

        [HttpPost]
        [Route("remove/{id}")]
        public async Task Remove(string id)
        {
            await _usersRepository.Remove(id);
        }
    }
}
