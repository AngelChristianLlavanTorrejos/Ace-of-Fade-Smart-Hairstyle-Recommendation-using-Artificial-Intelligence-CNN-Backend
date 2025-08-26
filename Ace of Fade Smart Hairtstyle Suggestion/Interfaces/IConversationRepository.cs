using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Interfaces
{
    public interface IConversationRepository
    {
        Task<Conversation?> GetConversationByIdAsync(int id);
        Task<Conversation> CreateConversationAsync(Conversation conversation);
        Task<IEnumerable<Conversation>> GetConversationsByChatRoomIdAsync(int id);
        Task<int> GetChatRoomIdByQueryParam(int ClientId, int AdminId);
    }
}