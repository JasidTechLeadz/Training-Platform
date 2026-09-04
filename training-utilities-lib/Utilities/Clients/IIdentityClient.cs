using Utilities.Models;

namespace Utilities.Clients;

public interface IIdentityClient
{
    Task<UserDto?> GetUser(Guid id);
}