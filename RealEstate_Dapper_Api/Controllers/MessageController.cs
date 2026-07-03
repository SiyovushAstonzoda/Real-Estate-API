using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.MessageRepository;

namespace RealEstate_Dapper_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMessageRepository _messageRepository;

    public MessageController(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    [HttpGet("GetInBoxLastMessagesListByReceiver")]
    public async Task<IActionResult> GetInBoxLastMessagesListByReceiver(int id)
    {
        var values = await _messageRepository.GetInBoxLastMessagesListByReceiver(id);
        return Ok(values);
    }
}
