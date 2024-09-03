using Microsoft.AspNetCore.Mvc;

namespace WebDiaryAPI.Controllers
{
    // [ApiController] attribute is used to indicate that the class is a controller
    [ApiController]
    // [Route] attribute is used to specify the route template for the controller
    [Route("[controller]")]

    // WeatherForecastController class inherits from ControllerBase class
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[] {"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // [HttpGet] attributten definere en HTTP GET metode med navnet GetWeatherForecast
        [HttpGet(Name = "GetWeatherForecast")]
        // Get metode der returnere en IEnumerable af WeatherForecast objekter
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
    }
}
