using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OMDbApi.Api.Services
{
    interface IContentSerialiser
    {
        Task<T> DeserialiseAsync<T>(HttpContent httpContent);
        Task<HttpContent> SerialiseAsync<T>(T item); 
    }
}
