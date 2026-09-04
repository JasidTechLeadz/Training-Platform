using Microsoft.Extensions.Configuration;
using Utilities.Configuration;


namespace Utilities.Extensions;


public static class ConfigurationExtensions
{
    public static JwtSettings ValidateJwtSettings(
        this IConfiguration configuration)
    {
        var settings = configuration
            .GetSection("JwtSettings")
            .Get<JwtSettings>();


        if(settings == null)
        {
            throw new Exception(
                "JwtSettings configuration is missing"
            );
        }


        if(string.IsNullOrWhiteSpace(settings.Secret))
        {
            throw new Exception(
                "JWT Secret is missing"
            );
        }


        if(settings.ExpiryMinutes <= 0)
        {
            throw new Exception(
                "JWT ExpiryMinutes must be greater than zero"
            );
        }


        return settings;
    }
}