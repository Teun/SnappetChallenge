using System.Net.Http;
using ApiService;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Tests
{
    public class ApiServiceIntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ApiServiceIntegrationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void GetUsersTest()
        {
            using HttpClient client = BuildClient();
            var response = await client.GetAsync("Reports/Users?begin=2015-03-30&end=2015-03-30");
            Assert.True(response.IsSuccessStatusCode);
            var result = await response.Content.ReadAsStringAsync();
            Assert.True(result.Length > 0);
        }

        private HttpClient BuildClient()
        {
            return _factory.WithWebHostBuilder(c => { }).CreateClient();
        }
    }
}

