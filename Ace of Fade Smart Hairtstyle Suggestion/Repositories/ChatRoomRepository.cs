using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Data;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.ChatRoom;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Interfaces;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;
using Microsoft.EntityFrameworkCore;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Repositories
{
    public class ChatRoomRepository : IChatRoom
    {
        private readonly SmartHairstyleSuggestionContext _context;

        public ChatRoomRepository(SmartHairstyleSuggestionContext context)
        {
            _context = context;
        }

        public async Task<ChatRoom?> GetChatRoomByIdAsync(int id)
        {
            return await _context.ChatRooms.FindAsync(id);
        }

        public async Task<ChatRoom> CreateChatRoomAsync(ChatRoom chatRoom)
        {
            _context.ChatRooms.Add(chatRoom);
            await _context.SaveChangesAsync();
            return chatRoom;
        }

        public async Task<bool> IsChatRoomExist(IsChatRoomExistRequest chatRoomExistRequest)
        {
            return await _context.ChatRooms.Where(cr => cr.ClientId == chatRoomExistRequest.ClientId &&
                cr.AdminId == chatRoomExistRequest.AdminId).AnyAsync();
        }

        public async Task<int> GetChatRoomIdAsync(GetChatRoomIdRequest chatRoomIdRequest)
        {
            var chatRoomId = await _context.ChatRooms.Where(c => c.ClientId == chatRoomIdRequest.ClientId &&
                c.AdminId == chatRoomIdRequest.AdminId)
                .Select(c => c.Id)
                .FirstOrDefaultAsync();

            return chatRoomId;
        }
    }
}
