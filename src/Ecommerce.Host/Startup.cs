using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

namespace Ecommerce.Host
{
    public class Startup
    {
        private readonly IWebHostEnvironment environment;
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            this.configuration = configuration;
            this.environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ApiConfiguration.ConfigureServices(services, environment, configuration);
            services.AddCors();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app)
        {
            ApiConfiguration.Configure(app, host =>
            {
                if (environment.IsDevelopment())
                {
                    host.UseSwagger();
                    host.UseSwaggerUI();
                }

                var allowedOrigins = configuration.GetSection("AllowedOrigins").Get<IEnumerable<string>>();

                host.UseCors(policy =>
                         policy.WithOrigins(allowedOrigins.ToArray())
                         .AllowAnyMethod()
                         .WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization)
                         .AllowCredentials());

                return host;
            });
        }
    }
}
