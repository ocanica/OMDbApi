using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OMDbApi.Models
{
    public class Movie
    {
        [JsonPropertyName("imdbID")]
        public string IMDbId { get; set; }
        [JsonPropertyName("Title")]
        public string Title { get; set; }
        [JsonPropertyName("Released")]
        public string Released { get; set; }
        [JsonPropertyName("Runtime")]
        public string Runtime { get; set; }
        [JsonPropertyName("Rated")]
        public string Rated { get; set; }
        [JsonPropertyName("Genre")]
        public string Genre { get; set; }
        [JsonPropertyName("Plot")]
        public string Plot { get; set; }
        [JsonPropertyName("Director")]
        public string Director { get; set; }
        [JsonPropertyName("Actors")]
        public string Actors { get; set; }
        [JsonPropertyName("Writer")]
        public string Writer { get; set; }
        [JsonPropertyName("Poster")]
        public string Poster { get; set; }
        [JsonPropertyName("imdbRating")]
        public string imdbRating { get; set; }
        [JsonPropertyName("Ratings")]
        public IEnumerable<Ratings> Ratings { get; set; }
    }
}
