using chum_chat_backend.App.Interfaces.Services;
using chum_chat_backend.App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chum_chat_backend.App.Controllers;

[Authorize]
[Route("api/chat")]
[ApiController]
public class ChatController(IChatService chatService): ControllerBase
{
    
    [HttpPost("create")]
    public async Task<ActionResult<Chat>> CreateChat([FromBody] ChatCreate chat)
    {
        try
        {
            var createdChat = await chatService.CreateChat(chat);
            return Ok(createdChat);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<Chat>> GetChat(string id)
    {
        try
        {
            return Ok(await chatService.GetChat(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("get/list/{userId}")]
    public async Task<ActionResult<Chat>> GetChats(string userId)
    {
        try
        {
            return Ok(await chatService.GetChats(userId));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    
    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<bool>> DeleteChat(string id)
    {
        try
        {
            await chatService.DeleteChat(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    

    [HttpPut("update")]
    public async Task<ActionResult<Chat>> UpdateChat([FromBody] ChatUpdate chat)
    {
        try
        {
            return Ok(await chatService.UpdateChat(chat));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}