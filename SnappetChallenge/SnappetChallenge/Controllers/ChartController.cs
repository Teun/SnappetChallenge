using SnappetChallenge.DAL.Data;
using SnappetChallenge.DAL.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SnappetChallenge.Controllers
{
    [RoutePrefix("Chart")]
    public class ChartController : ApiController
    {
        private readonly DateTime NOW = new DateTime(2015, 3, 24, 11, 30, 00);
        private IChartService _chartService;

        public ChartController(IChartService chartService)
        {
            _chartService = chartService;
        }

        [Route("Difficulty")]
        public ChartData GetDifficultyChart()
        {
            return _chartService.CreateDifficultyChart(NOW.AddDays(-1), NOW);
        }
    }
}
