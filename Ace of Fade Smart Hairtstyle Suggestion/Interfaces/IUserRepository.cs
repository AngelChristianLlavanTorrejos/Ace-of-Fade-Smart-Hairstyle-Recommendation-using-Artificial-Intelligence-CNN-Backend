using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.User;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUserAsync(UserCreateRequestDto dto);
        Task<bool> IsEmailTakenAsync(string email);
        Task<User?> GetUserByEmailAsync(string email);
        Task<List<User>> GetClientInformationAsync();

        Task<(int totalCount, IEnumerable<User> users)> GetUserWhereRoleIsClient(int pageNumber, int pageSize, string? search = null);
        Task<User?> UpdatePersonalInformation(int id, UserUpdateProfileInformation dto);
        Task<User?> FetchUserById(int id);
        Task<bool> ChangePassword(int id, ChangePasswordRequestDto dto);
    }
}
