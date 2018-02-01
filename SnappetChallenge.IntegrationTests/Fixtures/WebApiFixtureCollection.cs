using System;
using System.Collections.Generic;
using System.Text;

namespace SnappetChallenge.IntegrationTests.Fixtures
{
    using Xunit;

    [CollectionDefinition(nameof(WebApiFixtureCollection))]
    public class WebApiFixtureCollection : ICollectionFixture<WebApiIntegrationTestFixture>
    {
    }
}
