using Microsoft.AspNetCore.Mvc;
using RealWorld.Api.Domain;
using RealWorld.Api.Services;

namespace RealWorld.Api.Controllers;

[ApiController]
[Route("/api/users")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    private readonly IUserService _service;

    public UserController(IUserService service, ILogger<UserController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpPost]
    public ObjectResult RegisterUser([FromBody] RegisterUserRequest request)
    {
        var user = _service.RegisterUser(request);

        return new OkObjectResult(user);
    }
}

