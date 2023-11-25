using Microsoft.AspNetCore.Mvc;
using project_four_Application;
using project_four_Domain;
using project_four_Infrastructure;

namespace project_four_Api.Controllers
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
        public IActionResult App4Get()
        {
            Application4Get application4Get = new Application4Get();
            return Ok(application4Get.Name);
        }
        [HttpGet]
        public IActionResult DomainGet4()
        {
            Domain4Get domain4Get = new Domain4Get();
            return Ok(domain4Get.Name);
        }
        [HttpGet]
        public IActionResult Infrastructureget4()
        {
            Infrastructure4Get infrastructure4Get = new Infrastructure4Get();
            return Ok(infrastructure4Get.Name);
        }
    }
}
