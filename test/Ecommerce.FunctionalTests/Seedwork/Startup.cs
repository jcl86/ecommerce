using Acheve.AspNetCore.TestHost.Security;
using Acheve.TestHost;
using Ecommerce.Core.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Core.FunctionalTests
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            this.configuration = configuration;
            this.environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ApiConfiguration.ConfigureServices(services, environment, configuration)
                .AddAuthentication(setup =>
                {
                    setup.DefaultAuthenticateScheme = TestServerDefaults.AuthenticationScheme;
                    setup.DefaultChallengeScheme = TestServerDefaults.AuthenticationScheme;
                })
                .AddTestServer(options =>
                {
                    options.NameClaimType = "name";
                    options.RoleClaimType = "role";
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            ApiConfiguration.Configure(app, host => host);
        }
    }
}
