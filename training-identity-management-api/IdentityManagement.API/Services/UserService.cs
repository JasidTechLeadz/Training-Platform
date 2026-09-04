using IdentityManagement.API.Interfaces;
using IdentityManagement.API.Models;

namespace IdentityManagement.API.Services;

public class UserService
{
    private readonly IUserRepository repository;


    public UserService(IUserRepository repository)
    {
        this.repository = repository;
    }


    public User? GetUser(Guid id)
    {
        return repository.GetUser(id);
    }


    public bool DeleteUser(Guid id)
    {
        var user = repository.GetUser(id);

        if(user == null)
        {
            return false;
        }

        repository.DeleteUser(id);

        return true;
    }


    public bool OptOutUser(Guid id)
    {
        var user = repository.GetUser(id);

        if(user == null)
        {
            return false;
        }

        repository.OptOutUser(id);

        return true;
    }
}