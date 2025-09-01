using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Data;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Interfaces;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;
using Microsoft.EntityFrameworkCore;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Repositories
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly SmartHairstyleSuggestionContext _context;

        public ConversationRepository(SmartHairstyleSuggestionContext context)
        {
            _context = context;
        }

        public async Task<Conversation> CreateConversationAsync(Conversation conversation)
        {
            _context.Conversations.Add(conversation);
            await _context.SaveChangesAsync();
            return conversation;
        }

        public Task<int> GetChatRoomIdByQueryParam(int ClientId, int AdminId)
        {
            throw new NotImplementedException();
        }

        public async Task<Conversation?> GetConversationByIdAsync(int id)
        {
            return await _context.Conversations.FindAsync(id);
        }

        public async Task<IEnumerable<Conversation>> GetConversationsByChatRoomIdAsync(int id)
        {
            return await _context.Conversations.Where(c => c.ChatRoomId == id)
                .OrderByDescending(c => c.SentAt)
                .ToListAsync();
        }
    }
}