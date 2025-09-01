using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.ChatRoom;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Mapper
{
    public static class ChatRoomMapper
    {
        public static ChatRoom ToChatRoom(this CreateChatRoomRequest chatRoom)
        {
            return new ChatRoom
            {
                ClientId = chatRoom.ClientId,
                AdminId = chatRoom.AdminId
            };
        }

        public static CreateChatRoomResponse ToChatRoomResponse (this ChatRoom chatRoom)
        {
            return new CreateChatRoomResponse
            {
                Id = chatRoom.Id,
                ClientId = chatRoom.ClientId,
                AdminId = chatRoom.AdminId
            };
        }

        public static GetChatRoomResponse ToGetChatRoomResponse(this ChatRoom chatRoom)
        {
            return new GetChatRoomResponse
            {
                Id = chatRoom.Id,
                ClientName = chatRoom.Client.FirstName + " " +
                    (string.IsNullOrEmpty(chatRoom.Client.MiddleName) ? chatRoom.Client.MiddleName + " " : "") +
                    chatRoom.Client.LastName

            };
        }
    }
}
