using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.Conversation;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Interfaces;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversationController : Controller
    {
        private readonly IConversationRepository _conversationRepo;

        public ConversationController(IConversationRepository conversationRepo)
        {
            _conversationRepo = conversationRepo;
        }

        [HttpGet("GetConversationById/{id:int}")]
        public async Task<IActionResult> GetConversationById(int id)
        {
            var conversation = await _conversationRepo.GetConversationByIdAsync(id);

            if (conversation == null) return NotFound();

            return Ok(conversation);
        }

        [HttpPost("CreateConversation")]
        public async Task<IActionResult> CreateConversation (CreateConversationRequest conversationRequest)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newConversation = conversationRequest.ToConversation();

            await _conversationRepo.CreateConversationAsync(newConversation);

            return CreatedAtAction(nameof(GetConversationById),
                new { id = newConversation.Id },
                newConversation.ToConversationResponse());
        }

        [HttpGet("GetConversationsByChatRoomId/{id:int}")]
        public async Task<IActionResult> GetConversationsByChatRoomId(int id)
        {
            var conversations = await _conversationRepo.GetConversationsByChatRoomIdAsync(id);
            return Ok(conversations.Select(c => c.ToConversationResponse()));
        }
    }
}
