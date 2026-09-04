using IdentityManagement.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdentityManagement.API.Controllers;


[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly UserService service;


    public UsersController(UserService service)
    {
        this.service = service;
    }


    // GET api/users/{id}
    [HttpGet("{id}")]
    public IActionResult GetUser(Guid id)
    {
        var user = service.GetUser(id);


        if(user == null)
        {
            return NotFound();
        }


        return Ok(user);
    }



    // DELETE api/users/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(Guid id)
    {
        var deleted = service.DeleteUser(id);


        if(!deleted)
        {
            return NotFound();
        }


        return NoContent();
    }



    // POST api/users/{id}/opt-out
    [HttpPost("{id}/opt-out")]
    public IActionResult OptOutUser(Guid id)
    {
        var optedOut = service.OptOutUser(id);


        if(!optedOut)
        {
            return NotFound();
        }


        return Ok(new
        {
            message = "User successfully opted out"
        });
    }
}