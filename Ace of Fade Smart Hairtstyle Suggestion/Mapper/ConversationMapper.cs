using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.Conversation;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Mapper
{
    public static class ConversationMapper
    {
        public static Conversation ToConversation (this CreateConversationRequest conversationRequest)
        {
            return new Conversation
            {
                ChatRoomId = conversationRequest.ChatRoomId,
                SenderId = conversationRequest.SenderId,
                Content = conversationRequest.Content,
            };
        }

        public static CreateConversationResponse ToConversationResponse (this Conversation conversation)
        {
            return new CreateConversationResponse
            {
                Id = conversation.Id,
                ChatRoomId = conversation.ChatRoomId,
                SenderId = conversation.SenderId,
                Content = conversation.Content,
                SentAt = conversation.SentAt
            };
        }
    }
}
