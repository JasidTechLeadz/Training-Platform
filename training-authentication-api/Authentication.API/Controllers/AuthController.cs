using Authentication.API.Models;
using Authentication.API.Services;
using Microsoft.AspNetCore.Mvc;


namespace Authentication.API.Controllers;


[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly TokenService tokenService;


    public AuthController(TokenService tokenService)
    {
        this.tokenService = tokenService;
    }


    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var token = tokenService.GenerateToken(
            request.Email
        );

console.WriteLine($" Testing Generated Token: {token}"
);
        return Ok(new
        {
            accessToken = token
        });
    }
}