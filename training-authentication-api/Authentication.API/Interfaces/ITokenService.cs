using Utilities.Configuration;

namespace Authentication.API.Interfaces;

public interface ITokenService
{
    string GenerateToken(
        Guid userId,
        string email
    );
}