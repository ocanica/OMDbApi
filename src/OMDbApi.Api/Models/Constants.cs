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
            omdbConfigData = LoadConfigDataAsync().GetAwaiter().GetResult();
        }

        public async Task<OMDbConfigData> LoadConfigDataAsync()
        {
            using FileStream fs = File.OpenRead("config.json");
            return await JsonSerializer.DeserializeAsync<OMDbConfigData>(fs);
        }
    }
}
