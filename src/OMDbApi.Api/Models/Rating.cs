using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMDbApi.Api.Models
{
    public class Rating
    {
        public Guid UserId { get; set; }
        public string IMDbId { get; set; }
        public int MovieRating { get; set; }
    }
}
