using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OMDbApi.Models
{
    public class RatingsDto
    {
        [JsonPropertyName("Source")]
        public string Source { get; set; }

        [JsonPropertyName("Value")]
        public string Value { get; set; }
    }
}
