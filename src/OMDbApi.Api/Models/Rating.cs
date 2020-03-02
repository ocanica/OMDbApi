using System.Text.Json.Serialization;

namespace OMDbApi.Models
{
    public class Rating
    {
        [JsonPropertyName("Source")]
        public string Source { get; set; }
        [JsonPropertyName("Value")]
        public string Value { get; set; }
    }
}
