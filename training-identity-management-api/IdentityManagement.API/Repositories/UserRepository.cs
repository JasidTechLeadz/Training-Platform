using IdentityManagement.API.Interfaces;
using IdentityManagement.API.Models;

namespace IdentityManagement.API.Repositories;


public class UserRepository : IUserRepository
{
    private readonly List<User> users = new();


    public UserRepository()
    {
        users.Add(
            new User
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Email = "john@test.com",
                Name = "John",
                IsOptedOut = false
            }
        );
    }


    public User? GetUser(Guid id)
    {
        return users.FirstOrDefault(x => x.Id == id);
    }


    public void DeleteUser(Guid id)
    {
        var user = GetUser(id);

        if(user != null)
        {
            users.Remove(user);
        }
    }


    public void OptOutUser(Guid id)
    {
        var user = GetUser(id);

        if(user != null)
        {
            user.IsOptedOut = true;
        }
    }
}