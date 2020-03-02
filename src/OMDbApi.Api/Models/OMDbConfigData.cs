using System.Text.Json.Serialization;

namespace OMDbApi.Models
{
    public struct OMDbConfigData
    {
        [JsonPropertyName("apiKey")]
        public string ApiKey { get; private set; }
        [JsonPropertyName("baseUri")]
        public string BaseUri { get; private set; }
    }
}
