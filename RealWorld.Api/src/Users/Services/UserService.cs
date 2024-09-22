
public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;

    public UserService(ILogger<UserService> logger)
    {
        _logger = logger;
    }

    public User RegisterUser(RegisterUserRequest request)
    {
        var user = new User(
            Email: request.Email,
            Username: request.Username,
            Bio: "",
            Image: "",
            Token: ""
        );

        return user;
    }
}