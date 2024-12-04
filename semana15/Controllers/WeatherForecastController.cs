using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using semana15.dto.res;

namespace semana15.Controllers
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


        [Authorize]
        [HttpGet(Name = "Get2")]
        public IEnumerable<PersonResponse> Get2()
        {
            List<PersonResponse> personas = new List<PersonResponse>();

            for (int i = 1; i <= 100; i++)
            {
                PersonResponse persona = new PersonResponse();
                persona.FirstName = "Persona" + i;
                persona.LastName = "Apellido" + i;

                personas.Add(persona);
            }

            return personas;
        }

    }

}