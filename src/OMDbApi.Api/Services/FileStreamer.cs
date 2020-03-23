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
            LoadConfigDataAsync(omdbConfigData).GetAwaiter().GetResult();
        }

        public async Task LoadConfigDataAsync(OMDbConfigData x)
        {
            /*using (FileStream fs = File.OpenRead("config.json"))
                omdbConfigData = await JsonSerializer.DeserializeAsync<OMDbConfigData>(fs);*/
            var json = string.Empty;
            using (var file = File.OpenRead("config.json"))
            using (var streamReader = new StreamReader(file))
                json = await streamReader.ReadToEndAsync().ConfigureAwait(false);
            x = JsonSerializer.Deserialize<OMDbConfigData>(json);
        }
    }
}
