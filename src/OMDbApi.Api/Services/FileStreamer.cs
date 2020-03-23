using OMDbApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OMDbApi.Api.Services
{
    public class FileStreamer
    {
        public OMDbConfigData omdbConfigData;
        public FileStreamer()
        {
            omdbConfigData = new OMDbConfigData();
            LoadConfigDataAsync().GetAwaiter().GetResult();
        }

        public async Task LoadConfigDataAsync()
        {
            using (FileStream fs = File.OpenRead("config.json"))
                omdbConfigData = await JsonSerializer.DeserializeAsync<OMDbConfigData>(fs);
        }
    }
}
