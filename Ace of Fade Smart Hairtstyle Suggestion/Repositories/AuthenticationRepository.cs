using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Data;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.Authentication;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly SmartHairstyleSuggestionContext _dbContext;

        public AuthenticationRepository(SmartHairstyleSuggestionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> IsAuthenticatedAsync(AuthenticationRequestDto dto)
        {
            var sql = "EXEC IsAuthenticated @Email, @Password";

            var parameters = new[]
            {
                new SqlParameter("@Email", dto.Email),
                new SqlParameter("@Password", dto.Password)
            };

            var user = await _dbContext.Users
                .FromSqlRaw(sql, parameters)
                .ToListAsync();

            return user.Any();
        }
    }
}   