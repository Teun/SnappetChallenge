namespace SnappetChallenge.IntegrationTests.Fixtures
{
    using System;
    using SnappetChallenge.WebApi;

    using Xunit.AspNetCore.Integration;

    /// <summary>
    /// The web api integration test fixture.
    /// </summary>
    public class WebApiIntegrationTestFixture : AbstractIntegrationTestFixture<Startup>
    {
        public WebApiIntegrationTestFixture() : base(null, "SnappetChallenge")
        {
        }
    }
}
