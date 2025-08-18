using Microsoft.AspNetCore.SignalR;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.Authentication
{
    public class AuthenticationResponseDto
    {
        public bool IsSuccess { get; set; }
        public int UserId { get; set; }
        public string? Role { get; set; }
        public string? Name { get; set; }
    }
}
