using Microsoft.EntityFrameworkCore;
using OMDbApi.Api.Models;

namespace OMDbApi.Api.Data
{
    public class OMDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public OMDbContext(DbContextOptions<OMDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>()
                .HasKey(c => new { c.UserId, c.IMDbId });
        }
    }
}
