using chum_chat_backend.App.Interfaces.Services;
using chum_chat_backend.App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chum_chat_backend.App.Controllers;

[Authorize]
[Route("api/friend-request")]
[ApiController]
public class FriendRequestController(IFriendRequestService  friendRequestService): ControllerBase
{
    
    [HttpPost("create")]
    public async Task<ActionResult<FriendRequest>> Post(FriendRequestCreate friendReq)
    {
        try
        {
            return Ok(await friendRequestService.CreateFriendRequest(friendReq));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpGet("get/{id}")]
    public async Task<ActionResult<FriendRequest>> Get(string id)
    {
        try
        {
            return Ok(await friendRequestService.GetFriendRequest(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpGet("get-list/{userId}")]
    public async Task<ActionResult<List<FriendRequestUserDto>>> GetList(string userId)
    {
        try
        {
            return Ok(await friendRequestService.GetFriendRequests(userId));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("get-friends/{userId}")]
    public async Task<ActionResult<FriendRequestUserDto>> GetFriends(string userId)
    {
        try
        {
            return Ok(await friendRequestService.GetFriendRequests(userId));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpDelete("delete")]
    public async Task<ActionResult<bool>> Delete(FriendRequestDelete friendReq)
    {
        try
        {
            if(await friendRequestService.DeleteFriendRequest(friendReq)) return Ok();
            return BadRequest("Unknown error deleting the friend request");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("update")]
    public async Task<ActionResult<FriendRequest>> Update(FriendRequestUpdate friendReq)
    {
        try
        {
            return Ok(await friendRequestService.UpdateFriendRequest(friendReq));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}