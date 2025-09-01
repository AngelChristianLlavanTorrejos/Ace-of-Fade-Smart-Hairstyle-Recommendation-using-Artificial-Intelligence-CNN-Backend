using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.ChatRoom;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Interfaces
{
    public interface IChatRoom
    {
        Task<ChatRoom?> GetChatRoomByIdAsync(int id);
        Task<ChatRoom> CreateChatRoomAsync (ChatRoom chatRoom);
        Task<bool> IsChatRoomExist(IsChatRoomExistRequest chatRoomExist);
        Task<int> GetChatRoomIdAsync(GetChatRoomIdRequest chatRoomIdRequest);
        Task<IEnumerable<ChatRoom>> GetChatRooms();
    }
}
