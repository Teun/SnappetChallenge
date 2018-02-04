namespace SnappetChallenge.IntegrationTests
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Xunit;

    public class StudentsWorkingResultControllerTests : WebApiTests
    {
        private readonly string routeTemplate = "api/StudentsWorkingResult/from/{0}/to/{1}";

        private readonly DateTime utmostDateFrom = DateTime.SpecifyKind(new DateTime(2015, 03, 24), DateTimeKind.Utc);
        private readonly DateTime utmostDateTo = DateTime.SpecifyKind(new DateTime(2015, 03, 24, 11, 30, 00), DateTimeKind.Utc);

        [Fact]
        public async Task SimpleGettingData()
        {
            var route = string.Format(this.routeTemplate, this.utmostDateFrom.ToString("O"), this.utmostDateTo.ToString("O"));

            HttpResponseMessage response = await this.client.GetAsync(route);

            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
