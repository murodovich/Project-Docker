using Microsoft.AspNetCore.Mvc;
using Project_one_Application;
using Project_two_Application;
using project_two_Domain;
using project_two_Infrastructure;

namespace Project_two.Controllers
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
        public IActionResult ApplicationGet()
        {
            AplicationGet2 aplicationGet2 = new AplicationGet2();
            return Ok(aplicationGet2.Name);
        }
        [HttpGet]
        public IActionResult GetDomain2()
        {
            DomainGet2 domainGet2 = new DomainGet2();
            return Ok(domainGet2.Name);

        }
        [HttpGet]
        public IActionResult GetInfrastructure()
        {
            InfrastuctureGet2 infrastuctureGet2 = new InfrastuctureGet2();
            return Ok(Ok(infrastuctureGet2.Name));
        }
    }
}
