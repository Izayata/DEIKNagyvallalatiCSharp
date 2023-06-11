using Microsoft.AspNetCore.Mvc;

namespace SzerverApp.Controllers
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
        private IGuidService _guidService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IGuidService guidService)
        {
            _logger = logger;
            _guidService = guidService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        //ENDPOINT CREATION
        [HttpGet("guid")]
        public string GetGuid() 
        { 
            return _guidService.Guid.ToString();
        }
    }
}