using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Data;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.User;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Interfaces;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Mapper;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SmartHairstyleSuggestionContext _dbContext;

        public UserRepository(SmartHairstyleSuggestionContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateUserAsync(UserCreateRequestDto dto)
        {
            var sql = "EXEC CreateUserProcedure @Role, @FirstName, @LastName, @Email, @Password";

            var parameteres = new[]
            {
                new SqlParameter("@Role", dto.Role),
                new SqlParameter("@FirstName", dto.FirstName),
                new SqlParameter("@LastName", dto.LastName),
                new SqlParameter("@Email", dto.Email),
                new SqlParameter("@Password", dto.Password)
            };

            await _dbContext.Database.ExecuteSqlRawAsync(sql, parameteres);
        }

        public async Task<bool> IsEmailTakenAsync(string email)
        {
            return await _dbContext.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<List<User>> GetClientInformationAsync()
        {
            return await _dbContext.Users.Where(u => u.Role == "Client").ToListAsync();
        }

        public async Task<(int totalCount, IEnumerable<User> users)> GetUserWhereRoleIsClient(int pageNumber, int pageSize, string? search = null)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 1;

            IQueryable<User> query = _dbContext.Users.Where(u => u.Role == "Client");

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(u => u.FirstName.Contains(search) ||
                    (u.MiddleName != null && u.MiddleName.Contains(search)) ||
                    u.LastName.Contains(search));
            }

            var totalCount = await query.CountAsync();

            var clients = await query
                .OrderBy(u => u.UserId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (totalCount, clients);
        }

        public async Task<User?> UpdatePersonalInformation(int id, UserUpdateProfileInformation dto)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserId == id);

            if (user == null) return null;

            user.UpdateUserInformation(dto);

            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User?> FetchUserById(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<bool> ChangePassword(int id, ChangePasswordRequestDto dto)
        {
            var query = "EXEC ChangePassword @Id, @CurrentPassword, @NewPassword, @ConfirmPassword";

            var parameters = new[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@CurrentPassword", dto.CurrentPassword),
                new SqlParameter("@NewPassword", dto.NewPassword),
                new SqlParameter("@ConfirmPassword", dto.ConfirmPassword)
            };

            var rowsAffected = await _dbContext.Database.ExecuteSqlRawAsync(query, parameters);

            if (rowsAffected != 1) return false;

            return true;
        }

        public async Task<int> GetClientsCount()
        {
            var clientsCount = await _dbContext.Users.Where(u => u.Role == "Client").CountAsync();
            return clientsCount;
        }

        public async Task<List<TopClientDto>> GetTopClients()
        {
            var topRegularClients = await _dbContext.Appointments.Include(a => a.Client)
                .Where(a => a.StatusId == 6)
                .GroupBy(a => a.Client.FirstName + " " + a.Client.LastName)
                .Select(g => new TopClientDto
                {
                    ClientName = g.Key,
                    CompletedAppointments = g.Count()
                })
                .OrderByDescending(x => x.CompletedAppointments)
                .Take(3)
                .ToListAsync();

            return topRegularClients;
        }
    }
}