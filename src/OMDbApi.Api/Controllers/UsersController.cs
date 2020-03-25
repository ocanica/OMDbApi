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
        public async Task<IActionResult> GetUsers()
        {
            var result = await _usersRepository.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("add")]
        public async Task AddUser()
        {
            var alex = new User
            {
                Username = "alexf",
                Password = "abc123",
                FirstName = "Alex",
                LastName = "Foley",
                DateRegistered = DateTime.Now,
                DateModified = DateTime.Now
            };

            await _usersRepository.Add(alex);
        }
    }
}
