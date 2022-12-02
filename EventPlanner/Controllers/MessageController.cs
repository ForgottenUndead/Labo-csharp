using EventPlanner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EventPlanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_messageService.GetAll());
        }

        [Authorize("connected")]
        [HttpPost]
        public IActionResult Post(NewMessageViewModel message)
        {
            ClaimsIdentity user = HttpContext.User.Identity as ClaimsIdentity;
            Message toSend = new Message
            {
                Content = message.Content,
                CreatedAt = DateTime.Now,
                Member_Id = int.Parse(user.FindFirst("MemberId").Value)
            };
            try
            {
                _messageService.Insert(toSend);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
