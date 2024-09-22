using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using RealWorld.Api.Controllers;
using RealWorld.Api.Services;
using Moq;
using RealWorld.Api.Domain;

namespace RealWorld.Api.Tests;

public class WeatherForecastTest
{

    private readonly WeatherForecastController _controller;
    private readonly Mock<IWeatherForecastService> _mockService;

    public WeatherForecastTest()
    {
        var logger = Mock.Of<ILogger<WeatherForecastController>>();

        _mockService = new Mock<IWeatherForecastService>();
        _controller = new WeatherForecastController(_mockService.Object, logger);
    }

    [Fact]
    public void TestGetWeatherForecast()
    {
        _mockService.Setup(service => service.GetForecast()).Returns(new[]
        {
            new WeatherForecast { Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)), TemperatureC = 17, Summary = "Cool" },
            new WeatherForecast { Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)), TemperatureC = 41, Summary = "Scorching" },
        }.AsEnumerable());

        var response = _controller.Get();

        Assert.NotNull(response);
        Assert.Equal(2, response.Count());
        Assert.Collection(response,
            item =>
            {
                Assert.Equal("Cool", item.Summary);
                Assert.Equal(17, item.TemperatureC);
            },
            item =>
            {
                Assert.Equal("Scorching", item.Summary);
                Assert.Equal(41, item.TemperatureC);
            }
        );
    }
};