using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMDbApi.Api.Contracts
{
    public interface IUser
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime DateModified { get; set; }
    }
}
