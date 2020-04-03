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
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(Rating rating)
        {

            if (DoesExist(rating))
            {
                Update(rating);
            } else
            {
                await _context.AddAsync(rating);
            }
        }

        public Rating CreateRating(int UserId, string IMDbId)
        {
            return new Rating { UserId = UserId, IMDbId = IMDbId };
        }

        public void Update(Rating rating)
        {
            _context.Update(rating);
        }

        public bool DoesExist(Rating rating)
        {
            if (_context.Ratings.Any(c => c.UserId == rating.UserId && c.IMDbId == rating.IMDbId))
                return true;
            return false;
        }
    }
}
