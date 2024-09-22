
using Microsoft.Extensions.Logging;
using Moq;
using RealWorld.Api.Controllers;
using RealWorld.Api.Domain;

namespace RealWorld.Api.Tests.Controllers;
public class UserTest
{

    private readonly UserController _controller;

    public UserTest()
    {
        var logger = Mock.Of<ILogger<UserController>>();

        _controller = new UserController(logger);
    }

    [Fact]
    public void ShouldRegisterUser()
    {
        var result = _controller.RegisterUser().Value as User;

        Assert.NotNull(result);
        Assert.Equal("", result.Email);
        Assert.Equal("", result.Username);
        Assert.Equal("", result.Bio);
        Assert.Equal("", result.Image);
        Assert.Equal("", result.Token);
    }
};