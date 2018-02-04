namespace SnappetChallenge.IntegrationTests
{
    using System.Net.Http;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;

    using SnappetChallenge.WebApi;

    public class WebApiTests
    { 
        private readonly TestServer server;
        protected readonly HttpClient client;

        public WebApiTests()
        {
            this.server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            this.client = this.server.CreateClient();
        }

    }
}
