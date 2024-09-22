using Microsoft.AspNetCore.Mvc;
using RealWorld.Api.Domain;
using RealWorld.Api.Services;

namespace RealWorld.Api.Controllers;

[ApiController]
[Route("/api/users")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public ObjectResult RegisterUser()
    {
        var user = new User(
            Email: "",
            Username: "",
            Bio: "",
            Image: "",
            Token: ""
        );

        return new ObjectResult(user);
    }
}

