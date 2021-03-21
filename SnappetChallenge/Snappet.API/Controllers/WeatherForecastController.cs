using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Snappet.Logic.Logger;

namespace Snappet.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILoggerManager _logger;
        private readonly Logic.Database.IDatabaseContext _ctx;
        private readonly AutoMapper.IMapper _mapper;

        public WeatherForecastController(ILoggerManager logger, 
            Logic.Database.IDatabaseContext ctx,
            AutoMapper.IMapper mapper)
        {
            _logger = logger;
            _ctx = ctx;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var teacher = new Logic.Security.Teacher();
            var rst = teacher.Login(_ctx, _mapper, "This is a key for testing JWT in the snappetCodeChallenge", "https://snappet.org/");


            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
