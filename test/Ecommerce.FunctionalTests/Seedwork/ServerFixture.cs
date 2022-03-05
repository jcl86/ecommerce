using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Core.FunctionalTests
{
    public class ServerFixture
    {
        public TestServer Server { get; }

        public T GetService<T>() => (T)Server.Services.GetService(typeof(T));

        public ServerFixture()
        {
            var host = new HostBuilder()
             .ConfigureWebHost(webBuilder =>
             {
                 webBuilder
                     .UseTestServer()
                     .UseStartup<Startup>()
                     .UseContentRoot(Directory.GetCurrentDirectory())
                     .ConfigureAppConfiguration(app =>
                     {
                         app.AddJsonFile("FunctionalTestsSettings.json", optional: true);
                         app.AddUserSecrets(typeof(ServerFixture).Assembly, optional: true);
                         app.AddEnvironmentVariables();
                     });
             })
             .Start();

            Server = host.GetTestServer();

            Initialize();
        }

        private void Initialize()
        {

        }
    }
}
