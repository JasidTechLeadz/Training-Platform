using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.IdentityModel.Tokens;

using Utilities.Configuration;


namespace Authentication.API.Services;


public class TokenService
{
    private readonly JwtSettings settings;


    public TokenService(JwtSettings settings)
    {
        this.settings = settings;
    }


    public string GenerateToken(string email)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(settings.Secret)
        );


        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256
        );


        var claims = new[]
        {
            new Claim(
                ClaimTypes.Email,
                email
            )
        };


        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(
                settings.ExpiryMinutes
            ),
            signingCredentials: credentials
        );


        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}