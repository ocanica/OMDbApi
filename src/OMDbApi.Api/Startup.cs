using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OMDbApi.Api.Data;
using OMDbApi.Models;

namespace OMDbApi.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public async Task ConfigureServices(IServiceCollection services)
        {
            // Stream OMDb token data
            /*var json = string.Empty;
            using (var file = File.OpenRead("config.json"))
            using (var streamReader = new StreamReader(file, new UTF8Encoding(false)))
            json = await streamReader.ReadToEndAsync().ConfigureAwait(false);
            var omdbConfigData = JsonSerializer.Deserialize<OMDbConfigData>(json);*/

            OMDbConfigData omdbConfigData;
            using (FileStream fs = File.OpenRead("config.json"))
                omdbConfigData = await JsonSerializer.DeserializeAsync<OMDbConfigData>(fs);

            services.AddDbContext<MoviesDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddHttpClient("OMDb", c =>
            {
                c.BaseAddress = new Uri($"{omdbConfigData.BaseUri}&apikey={omdbConfigData.ApiKey}");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
