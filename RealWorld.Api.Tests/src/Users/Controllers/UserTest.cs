
using Microsoft.Extensions.Logging;
using Moq;
using RealWorld.Api.Controllers;
using RealWorld.Api.Domain;

namespace RealWorld.Api.Tests.Controllers;
public class UserTest
{

    private readonly UserController _controller;
    private readonly Mock<IUserService> _mockService;

    public UserTest()
    {
        _mockService = new Mock<IUserService>();
        _controller = new UserController(_mockService.Object, Mock.Of<ILogger<UserController>>());
    }

    [Fact]
    public void ShouldRegisterUser()
    {
        var expectedUser = new User(
            Email: "bleh@xyz.com",
            Username: "bleh",
            Bio: "",
            Image: "",
            Token: ""
        );
        _mockService.Setup(x => x.RegisterUser(It.IsAny<RegisterUserRequest>())).Returns(expectedUser);

        var registerUserRequest = new RegisterUserRequest(
            Email: "bleh@xyz.com",
            Username: "bleh",
            Password: "wabbalubbadubdub"
        );

        var result = _controller.RegisterUser(registerUserRequest).Value as User;

        Assert.NotNull(result);
        Assert.Equal(expectedUser, result);
    }
};