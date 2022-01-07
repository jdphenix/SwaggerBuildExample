using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly Random random = new();

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(WeatherForecast))]
        [ProducesResponseType(404, Type = typeof(ProblemDetails))]
        public IActionResult Post()
        {
            if (random.NextDouble() <= .5)
            {
                return Ok(new WeatherForecast { Date = DateTime.Now, Summary = "Crazy", TemperatureC = 22 });
            }

            return NotFound(new ProblemDetails
            {
                Type = "https://globalhealth.com/no-such-city", 
                Detail = "No such city was found.", 
                Status = 404, 
                Title = "No such city was found."
            });
        }
    }
}