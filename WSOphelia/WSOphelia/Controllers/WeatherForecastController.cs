using Microsoft.AspNetCore.Mvc;

namespace WSOphelia.Controllers
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
            List<WeatherForecast> forecasts = new List<WeatherForecast>();
            forecasts.Add(new WeatherForecast() { WeatherId = 5, WeatherName = "Maria" });
            forecasts.Add(new WeatherForecast() { WeatherId = 6, WeatherName = "Jose" });
            return forecasts;
        }
    }
}