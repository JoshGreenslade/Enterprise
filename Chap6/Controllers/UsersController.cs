using Microsoft.AspNetCore.Mvc;

namespace Chap6.Controllers;

[ApiController]
public class UsersController : Controller
{

    private readonly IUsersService _usersService;
    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpPost("login")]
    public ActionResult<string> Login([FromBody] VeryPoorLoginRequestDto login)
    {
        var sessionAuthCode = _usersService.authorise(login, login.Username, login.Password);
        if (sessionAuthCode == null) return Forbid();
        return Ok(sessionAuthCode);
    }

    [HttpPost("register")]
    public ActionResult Register([FromBody] VeryPoorRegistrationRequestDto registration)
    {
        // We are a very poor registration, we just let them know its okay
        return Ok();
    }
}