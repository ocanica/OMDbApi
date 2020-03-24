using OMDbApi.Api.Services;
using OMDbApi.Models;
using System.Threading.Tasks;

namespace OMDbApi.Api.Models
{
    public class Constants
    {
        public Task<OMDbConfigData> omdbConfigData;

        public Constants()
        {
            // Poor implemention, blocking, will cause a deadlock
            omdbConfigData = FileStreamer.DeserialiseDataToModelAsync<OMDbConfigData>("config.json");
        }

        /*
        public static class Services
        {
            public const string OMDB_BASE_URL = "http://www.omdbapi.com/";
        }
        */
    }
}
