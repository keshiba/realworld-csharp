
using RealWorld.Api.Domain;

public interface IWeatherForecastService
{
    IEnumerable<WeatherForecast> GetForecast();
}