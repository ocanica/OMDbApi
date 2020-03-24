using OMDbApi.Api.Services;
using OMDbApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OMDbApi.Api.Models
{
    public class Constants
    {
        public OMDbConfigData omdbConfigData;

        public Constants()
        {
            // Poor implemention, blocking
            omdbConfigData = FileStreamer.DeserialiseDataToModelAsync<OMDbConfigData>("config.json")
                .GetAwaiter().GetResult();
        }

        // REFACTOR: This function seems out of place ihere
        // May need to revisit and create Service class
        public async Task<OMDbConfigData> LoadConfigDataAsync()
        {
            using FileStream fs = File.OpenRead("config.json");
            return await JsonSerializer.DeserializeAsync<OMDbConfigData>(fs);
        }
    }
}
