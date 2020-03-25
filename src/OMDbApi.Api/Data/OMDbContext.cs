using Microsoft.EntityFrameworkCore;
using OMDbApi.Models;

namespace OMDbApi.Data
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
                .HasKey(c => new { c.UserName, c.IMDbId });
        }
    }
}
