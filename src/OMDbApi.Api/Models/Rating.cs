using System;

namespace OMDbApi.Api.Models
{
    public class Rating
    {
        public string UserName { get; set; }
        public string IMDbId { get; set; }
        public int? MovieRating { get; set; }
    }
}
