using Microsoft.EntityFrameworkCore;
using OMDbApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMDbApi.Api.Data
{
    public class MoviesDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options)
            : base(options)
        {
        }
    }
}
