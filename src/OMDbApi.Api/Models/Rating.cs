using System;

namespace OMDbApi.Api.Models
{
    public class Rating
    {
        public int UserId { get; set; }
        public string IMDbId { get; set; }
        public int? MovieRating { get; set; }
    }
}
