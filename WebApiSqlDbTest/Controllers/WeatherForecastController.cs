using Microsoft.AspNetCore.Mvc;

namespace WebApiSqlDbTest.Controllers
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
        private readonly Data.DataContext ctx;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, Data.DataContext ctx)
        {
            _logger = logger;
            this.ctx = ctx;
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

        //[HttpGet(Name = "GetTargets")]
        //[Route("api/pera")]
        //public IEnumerable<ClassLib.Target> GetTargets()
        //{
        //    return ctx.Targets.ToList();
        //}
    }
}