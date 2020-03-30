using Microsoft.EntityFrameworkCore;
using OMDbApi.Api.Contracts;
using OMDbApi.Api.Data;
using OMDbApi.Api.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OMDbApi.Api.Services
{
    public class RatingsRepository : IRatingsRepository
    {
        private readonly OMDbContext _context;
        public RatingsRepository(OMDbContext context)
        {
            _context = context;
        }

        public async Task Add(Rating rating)
        {

            if (DoesExist(rating))
            {
                Update(rating);
                return;
            }
            
            await _context.AddAsync(CreateRating(rating.UserId, rating.IMDbId));
        }

        public Rating CreateRating(int UserId, string IMDbId)
        {
            return new Rating { UserId = UserId, IMDbId = IMDbId };
        }

        public void Update(Rating rating)
        {
            _context.Update(rating);
        }

        public Rating Get(int userId, string movieId)
        {
            Rating rating = new Rating()
            {
                UserId = userId, IMDbId = movieId
            };

            try
            {
                if (DoesExist(rating))
                    rating = CreateRating(userId, movieId);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
            return rating;
        }

        public bool DoesExist(Rating rating)
        {
            if (_context.Ratings.Any(c => c.UserId == rating.UserId && c.IMDbId == rating.IMDbId))
                return true;
            return false;
        }
    }
}
