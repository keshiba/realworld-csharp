using Microsoft.Extensions.Logging;
using RealWorld.Api.Controllers;
using Moq;
using RealWorld.Api.Domain;

namespace RealWorld.Api.Tests.Controllers;
public class WeatherForecastTest
{

    private readonly WeatherForecastController _controller;
    private readonly Mock<IWeatherForecastService> _mockService;

    public WeatherForecastTest()
    {
        _mockService = new Mock<IWeatherForecastService>();
        _controller = new WeatherForecastController(_mockService.Object, Mock.Of<ILogger<WeatherForecastController>>());
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