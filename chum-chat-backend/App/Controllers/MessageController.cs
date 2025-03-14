using chum_chat_backend.App.Interfaces.Services;
using chum_chat_backend.App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chum_chat_backend.App.Controllers;

[Authorize]
[Route("api/message")]
[ApiController]
public class MessageController(IMessageService messageService): ControllerBase
{

    [HttpPost("create")]
    public async Task<ActionResult<Message>> Post(MessageCreate message)
    {
        try
        {
            return Ok(await messageService.CreateMessage(message));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpGet("get/{id}")]
    public async Task<ActionResult<Message>> Get(string id)
    {
        try
        {
            return Ok(await messageService.GetMessage(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpGet("get-list/{chatId}")]
    public async Task<ActionResult<List<Message>>> GetList(string chatId)
    {
        try
        {
            return Ok(await messageService.GetMessages(chatId));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpDelete("delete")]
    public async Task<ActionResult<bool>> Delete(MessageDelete message)
    {
        try
        {
            if(await messageService.DeleteMessage(message)) return Ok();
            return BadRequest("Unknown error deleting the message");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("update")]
    public async Task<ActionResult<Message>> Update(MessageUpdate message)
    {
        try
        {
            return Ok(await messageService.UpdateMessage(message));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}