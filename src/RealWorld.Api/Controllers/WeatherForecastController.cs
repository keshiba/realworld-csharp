using Microsoft.AspNetCore.Mvc;
using RealWorld.Api.Domain;
using RealWorld.Api.Services;

namespace RealWorld.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastService _service;

    public WeatherForecastController(IWeatherForecastService service, ILogger<WeatherForecastController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return _service.GetForecast().ToArray();
    }
}
