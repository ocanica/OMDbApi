using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OMDbApi.Api.Models
{
    public class MovieMinified
    {
        [JsonPropertyName("imdbID")]
        public string IMDbId { get; set; }
        [JsonPropertyName("Title")]
        public string Title { get; set; }
        [JsonPropertyName("Year")]
        public string Year { get; set; }
        [JsonPropertyName("Type")]
        public string Type { get; set; }
        [JsonPropertyName("Poster")]
        public string Poster { get; set; }
    }
}
