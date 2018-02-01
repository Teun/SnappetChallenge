namespace SnappetChallenge.IntegrationTests
{
    using SnappetChallenge.IntegrationTests.Fixtures;

    using Xunit;
    using Xunit.AspNetCore.Integration;

    [Collection(nameof(WebApiFixtureCollection))]
    public class WebApiTests : AbstractTest<WebApiIntegrationTestFixture>
    {
        public WebApiTests(WebApiIntegrationTestFixture configuration)
            : base(configuration)
        {
        }
    }
}
