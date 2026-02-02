using Messenger.Api.Interfaces;
using Messenger.Api.Models.Chat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ChatsController(IChatService chatService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateChat([FromBody] ChatCreateModel model)
    {
        var chatId = await chatService.CreateChatAsync(model);
        return Ok(chatId);
    }

    [HttpGet("types")]
    public async Task<IActionResult> GetChatTypes()
    {
        var types = await chatService.GetAllTypes();
        return Ok(types);
    }
}