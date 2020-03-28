using OMDbApi.Api.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace OMDbApi.Api.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime DateModified { get; set; }
    }
}
