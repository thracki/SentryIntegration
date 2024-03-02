using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SentryProject.Services;

namespace SentryProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ISentryExceptionLog sentryCustomLoggger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ISentryExceptionLog sentryCustomLoggger)
        {
            _logger = logger;
            this.sentryCustomLoggger = sentryCustomLoggger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();

            try
            {
                throw new NotImplementedException("Test 2s");
            } 
            catch(Exception e)
            {
                this.sentryCustomLoggger.Log(e);
                throw;
            }

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
