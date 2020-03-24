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
        public static async Task<T> DeserialiseDataToModelAsync<T>(string file)
        {
            using FileStream fs = File.OpenRead(file);
            return await JsonSerializer.DeserializeAsync<T>(fs);
        }
    }
}
