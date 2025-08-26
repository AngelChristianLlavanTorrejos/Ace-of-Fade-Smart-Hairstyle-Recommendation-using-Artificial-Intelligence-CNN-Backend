using System.ComponentModel.DataAnnotations;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.ChatRoom
{
    public class CreateChatRoomRequest
    {
        [Required]
        public int ClientId { get; set; }
        [Required]
        public int AdminId { get; set; }
    }
}
