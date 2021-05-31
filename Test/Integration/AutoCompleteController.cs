using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;
using Snappet;
using Snappet.Model;

namespace Test.Integration
{
    public class AutoCompleteController
    {
        private TestServer _server;

        [SetUp]
        public void Setup()
        {
            //we could inject some services here to eliminate the dependency from the "data.json" file.
            //I am keeping this structure only for the sake of simplicity
            //Also, we should use web host builder factory to have a clean test structure
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
        }

        [Test]
        public async Task When_query_is_not_provided_get_returns_400()
        {
            using var client = _server.CreateClient();
            var response = await client.GetAsync("/AutoComplete");
            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Test]
        public async Task When_query_is_provided_get_returns_non_empty_result()
        {
            const string keyword = "402";
            const string type = "user";

            using var client = _server.CreateClient();
            var response = await client.GetAsync($"/AutoComplete?Keyword={keyword}&type={type}");
            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AutoCompleteResponse>(content);
            result.ShouldNotBeNull();
            result.Items.ShouldNotBeEmpty();
        }

        [Test]
        public async Task When_query_is_provided_and_there_are_results_item_count_is_same_as_query_count()
        {
            const string keyword = "402";
            const string type = "user";
            const int count = 2;

            using var client = _server.CreateClient();
            var response = await client.GetAsync($"/AutoComplete?Keyword={keyword}&type={type}&count={count}");
            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AutoCompleteResponse>(content);
            result.ShouldNotBeNull();
            result.Items.Length.ShouldBe(count);
        }
    }
}