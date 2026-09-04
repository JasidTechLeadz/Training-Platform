using IdentityManagement.API.Models;

namespace IdentityManagement.API.Interfaces;

public interface IUserRepository
{
    User? GetUser(Guid id);

    void DeleteUser(Guid id);

    void OptOutUser(Guid id);
}