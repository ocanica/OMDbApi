using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace OMDbApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieContoller : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MovieContoller(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
    }
}
