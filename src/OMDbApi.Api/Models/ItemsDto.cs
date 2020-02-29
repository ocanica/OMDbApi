using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OMDbApi.Models
{
    public class ItemDto
    {
        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [JsonPropertyName("Year")]
        public string Year { get; set; }

        [JsonPropertyName("Rated")]
        public string Rated { get; set; }

        [JsonPropertyName("Released")]
        public string Released { get; set; }

        [JsonPropertyName("Runtime")]
        public string Runtime { get; set; }

        [JsonPropertyName("Genre")]
        public string Genre { get; set; }

        [JsonPropertyName("Director")]
        public string Director { get; set; }

        [JsonPropertyName("Writer")]
        public string Writer { get; set; }

        [JsonPropertyName("Actors")]
        public string Actors { get; set; }

        [JsonPropertyName("Plot")]
        public string Plot { get; set; }

        [JsonPropertyName("Language")]
        public string Language { get; set; }

        [JsonPropertyName("Country")]
        public string Country { get; set; }

        [JsonPropertyName("Awards")]
        public string Awards { get; set; }

        [JsonPropertyName("Poster")]
        public string Poster { get; set; }

        [JsonPropertyName("Ratings")]
        public RatingsDto Ratings { get; set; }

        [JsonPropertyName("Metascore")]
        public string Metascore { get; set; }

        [JsonPropertyName("imdbRating")]
        public string imdbRating { get; set; }

        [JsonPropertyName("imdbVotes")]
        public string imdbVotes { get; set; }

        [JsonPropertyName("imdbID")]
        public string imdbID { get; set; }

        [JsonPropertyName("Type")]
        public string Type { get; set; }

        [JsonPropertyName("DVD")]
        public string DVD { get; set; }

        [JsonPropertyName("BoxOffice")]
        public string BoxOffice { get; set; }

        [JsonPropertyName("Production")]
        public string Production { get; set; }

        [JsonPropertyName("Website")]
        public string Website { get; set; }

        [JsonPropertyName("Response")]
        public string Response { get; set; }
    }
}
