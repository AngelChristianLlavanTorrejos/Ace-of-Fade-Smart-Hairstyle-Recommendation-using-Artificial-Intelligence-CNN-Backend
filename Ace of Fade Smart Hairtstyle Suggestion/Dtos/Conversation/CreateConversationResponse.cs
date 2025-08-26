using System.ComponentModel.DataAnnotations;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.Conversation
{
    public class CreateConversationResponse
    {
        public int Id { get; set; }
        public int ChatRoomId { get; set; }

        public int SenderId { get; set; }

        public string Content { get; set; } = null!;

        public DateTime? SentAt { get; set; }
    }
}
