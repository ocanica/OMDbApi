using System.Text.Json.Serialization;

namespace OMDbApi.Models
{
    public struct OMDbConfigData
    {
        [JsonPropertyName("baseUrl")]
        public string BaseUrl { get; set; }
        [JsonPropertyName("apiKey")]
        public string ApiKey { get; set; }
    }
}
