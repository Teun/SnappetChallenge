using System;
using Xunit;

namespace SnappetChallenge.IntegrationTests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Microsoft.AspNetCore.Mvc;

    using SnappetChallenge.IntegrationTests.Fixtures;
    using SnappetChallenge.WebApi.Controllers;

    public class ClassResultControllerTests : WebApiTests
    {
        //public ClassResultControllerTests() : base() { }

        public ClassResultControllerTests(WebApiIntegrationTestFixture configuration)
            : base(configuration)
        {
        }

        [Fact]
        public async Task Test1()
        {
            IActionResult x = await this.Fixture.SingleAsync<ClassResultController, IActionResult>(controller => controller.Get());
        }
    }
}
