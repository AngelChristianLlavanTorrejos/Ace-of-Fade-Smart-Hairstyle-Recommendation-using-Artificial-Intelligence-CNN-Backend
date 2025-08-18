using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.Authentication;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<bool> IsAuthenticatedAsync(AuthenticationRequestDto dto);
    }
}