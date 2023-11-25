using Microsoft.AspNetCore.Mvc;
using Project_one_Application;
using Project_one_Domain;
using Project_one_Infrastructure;

namespace project_one.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        public IActionResult GetApplication1()
        {
            ApplicationGet1 applicationGet1 = new ApplicationGet1();

            return Ok(applicationGet1.Name);
        }

        [HttpGet]
        public IActionResult GetDomain1()
        {
            DomainGet1 domainGet1 = new DomainGet1();
            return Ok(domainGet1.Name);
        }

        [HttpGet]
        public IActionResult GetInfrastructure1()
        {
            InfrastructureGet1 infrastructureGet1 = new InfrastructureGet1();
            return Ok(infrastructureGet1.Name);
        }

    }
}
