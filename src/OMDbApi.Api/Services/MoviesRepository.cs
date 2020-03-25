using Microsoft.EntityFrameworkCore;
using OMDbApi.Api.Contracts;
using OMDbApi.Api.Data;
using OMDbApi.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OMDbApi.Api.Services
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly OMDbContext _context;

        public MoviesRepository(OMDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> Get(string id)
        {
            var movie = _context.Movies;
            return await movie
                .FirstOrDefaultAsync(m => m.IMDbId == id);
        }

        public async Task Add(Movie entity)
        {
            await _context.AddAsync(entity);
            _context.SaveChanges();
        }

        public void Remove(Movie entity)
        {
            _context.RemoveRange(entity);
            _context.SaveChanges();
        }
    }
}
