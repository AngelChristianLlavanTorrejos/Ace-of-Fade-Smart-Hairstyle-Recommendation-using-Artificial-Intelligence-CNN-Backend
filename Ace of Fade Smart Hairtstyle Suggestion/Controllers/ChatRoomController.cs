using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.ChatRoom;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Interfaces;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatRoomController : Controller
    {
        private readonly IChatRoom _chatRoomRepo;

        public ChatRoomController(IChatRoom chatRoomRepo)
        {
            _chatRoomRepo = chatRoomRepo;   
        }

        [HttpGet("GetChatRoomById/{id:int}")]
        public async Task<IActionResult> GetChatRoomById (int id)
        {
            var chatRoom = await _chatRoomRepo.GetChatRoomByIdAsync(id);

            if (chatRoom == null) return NotFound();

            return Ok(chatRoom);
        }

        [HttpPost("CreateChatRoom")]
        public async Task<IActionResult> CreateChatRoom(CreateChatRoomRequest chatRoomRequest)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newChatRoom = chatRoomRequest.ToChatRoom();

            await _chatRoomRepo.CreateChatRoomAsync(newChatRoom);

            return CreatedAtAction(nameof(GetChatRoomById), 
                new { id = newChatRoom.Id }, 
                newChatRoom.ToChatRoomResponse());
        }

        [HttpPost("IsChatRoomExist")]
        public async Task<IActionResult> IsChatRoomExist([FromBody] IsChatRoomExistRequest chatRoomExistRequest)
        {
            var isChatRoomExist = await _chatRoomRepo.IsChatRoomExist(chatRoomExistRequest);

            if (!isChatRoomExist) return BadRequest();

            return NoContent();
        }

        [HttpPost("GetChatRoomId")]
        public async Task<IActionResult> GetChatRoomId([FromBody] GetChatRoomIdRequest chatRoomIdRequest)
        {
            var chatRoomId = await _chatRoomRepo.GetChatRoomIdAsync(chatRoomIdRequest);

            if (chatRoomId == 0) return BadRequest();

            return Ok(chatRoomId);
        }

        [HttpGet("GetChatRooms")]
        public async Task<IActionResult> GetChatRooms()
        {
            var chatRooms = await _chatRoomRepo.GetChatRooms();
            return Ok(chatRooms.Select(cr => cr.ToGetChatRoomResponse()));
        }
    }
}
