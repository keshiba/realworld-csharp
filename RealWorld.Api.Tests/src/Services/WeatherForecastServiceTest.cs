using RealWorld.Api.Services;

namespace RealWorld.Api.Tests.Services;

public class WeatherForecastServiceTest
{
    private readonly WeatherForecastService _service;

    public WeatherForecastServiceTest()
    {
        _service = new WeatherForecastService();
    }

    [Fact]
    public void TestGetWeatherForecast()
    {
        var response = _service.GetForecast();

        Assert.NotNull(response);
        Assert.Equal(5, response.Count());
        Assert.All(response, item =>
        {
            Assert.InRange(item.TemperatureC, -20, 55);
            Assert.Contains(item.Summary, new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            });
        });
    }
}