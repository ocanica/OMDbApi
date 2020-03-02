using OMDbApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OMDbApi.Api.Services
{
    public class JsonContentSerialiser : IContentSerialiser
    {
        public async Task<T> DeserialiseAsync<T>(HttpContent httpContent)
        {
            var response = await httpContent.ReadAsStreamAsync()
                .ConfigureAwait(false);
            return await JsonSerializer.DeserializeAsync<T>(response);
        }

        public Task<HttpContent> SerialiseAsync<T>(T item)
        {
            throw new NotImplementedException();
        }
    }
}
