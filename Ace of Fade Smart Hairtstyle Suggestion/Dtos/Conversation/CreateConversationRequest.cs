using System.ComponentModel.DataAnnotations;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.Conversation
{
    public class CreateConversationRequest
    {
        [Required]
        public int ChatRoomId { get; set; }
        [Required]
        public int SenderId { get; set; }
        [Required]
        public string Content { get; set; } = null!;

    }
}
