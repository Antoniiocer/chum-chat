using chum_chat_backend.App.Interfaces.Services;
using chum_chat_backend.App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chum_chat_backend.App.Controllers;

[Authorize]
[Route("api/user")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    
    [HttpPost("register")]
    public async Task<ActionResult<User>> Register([FromBody] UserCreate user)
    {
        try
        {
            var createdUser = await userService.Register(user);
            return Ok(createdUser);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<User>> GetUser(string id)
    {
        var user = await userService.GetUser(id);

        if (user == null)
            return NotFound("User not found");

        return Ok(user);
    }

    [HttpGet("get-list")]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        return Ok(await userService.GetUsers());
    }

    [HttpDelete("delete")]
    public async Task<ActionResult<User>> DeleteUser([FromBody] UserDelete user)
    {
        try
        {
            return Ok(await userService.DeleteUser(user));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("update")]
    public async Task<ActionResult<User>> UpdateUser([FromBody] UserUpdate user)
    {
        try
        {
            return Ok(await userService.UpdateUser(user));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    
}