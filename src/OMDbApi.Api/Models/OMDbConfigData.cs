using System.Text.Json.Serialization;

namespace OMDbApi.Api.Models
{
    public struct OMDbConfigData
    {
        [JsonPropertyName("baseUrl")]
        public string BaseUrl { get; set; }
        [JsonPropertyName("apiKey")]
        public string ApiKey { get; set; }
    }
}
