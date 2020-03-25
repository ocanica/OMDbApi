using Microsoft.EntityFrameworkCore;
using OMDbApi.Api.Models;
using OMDbApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMDbApi.Api.Data
{
    public class OMDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public OMDbContext(DbContextOptions<OMDbContext> options)
            : base(options)
        {
        }

    }
}
