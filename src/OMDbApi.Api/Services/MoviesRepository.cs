using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OMDbApi.Api.Data;
using OMDbApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OMDbApi.Api.Services
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly MoviesDbContext _context;

        public MoviesRepository(MoviesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieAsync(string title)
        {
            if (title == string.Empty)
                throw new ArgumentException();

            var movie = _context.Movies
                .FirstOrDefaultAsync(m => m.Title == title);
            if (movie == null)
                throw new NullReferenceException();

            return await movie;
        }

        public async Task AddMovie(Movie movie)
        {
            if (movie == null)
                throw new NullReferenceException();

            await _context.AddAsync(movie);
            _context.SaveChanges();
        }
    }
}
