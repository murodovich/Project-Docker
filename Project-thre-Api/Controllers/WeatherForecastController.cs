using Microsoft.AspNetCore.Mvc;
using project_thre_Application;
using project_thre_Domain;
using project_thre_Infrastructure;

namespace Project_thre_Api.Controllers
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
        public IActionResult Applicationget()
        {
            ApplicationGet3 applicationGet3 = new ApplicationGet3();
            return Ok(applicationGet3.Name);
        }
        [HttpGet]
        public IActionResult GetDomain3()
        {
            DomainGet3 domainGet3 = new DomainGet3();
            return Ok(domainGet3.Name);
        }
        [HttpGet]
        public IActionResult Infrastructure3()
        {
            InfrastructureGet3 infrastructureGet3 = new InfrastructureGet3();
            return Ok(infrastructureGet3.name);
        }
    }
}
