using Microsoft.EntityFrameworkCore;
using OMDbApi.Api.Contracts;
using OMDbApi.Api.Data;
using OMDbApi.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IQueryable<Movie> GetAll()
        {
            return _context.Set<Movie>().AsNoTracking();
        }

        public async Task<Movie> GetById(object id)
        {
            var movie = _context.Movies;
            return await movie
                .FirstOrDefaultAsync(m => m.IMDbId == id.ToString());
        }

        public async Task Add(Movie entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(object id)
        {
            var entity = await GetById(id);
            _context.RemoveRange(entity);
            await _context.SaveChangesAsync();
        }
    }
}
