using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Data;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.Barber;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Interfaces;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;
using Microsoft.EntityFrameworkCore;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Repositories
{
    public class BarberRepository : IBarberRepository
    {
        private readonly SmartHairstyleSuggestionContext _dbContext;

        public BarberRepository(SmartHairstyleSuggestionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Barber> CreateBarber(Barber barber)
        {
            _dbContext.Barbers.Add(barber);
            await _dbContext.SaveChangesAsync();
            return barber;
        }

        public async Task<List<Barber>> GetBarbers()
        {
            return await _dbContext.Barbers.ToListAsync();
        }

        public async Task<int> GetBarbersCount()
        {
            var barbersCount = await _dbContext.Barbers.CountAsync();
            return barbersCount;
        }

        public async Task<List<TopBarberDto>> GetTopPerformingBarbers()
        {
            var topPerformingBarbers = await _dbContext.Appointments.Include(a => a.Barber)
                .Where(a => a.StatusId == 6)
                .GroupBy(a => a.Barber.Name)
                .Select(g => new TopBarberDto
                {
                    BarberName = g.Key,
                    CompletedAppointments = g.Count()
                })
                .OrderByDescending(x => x.CompletedAppointments)
                .Take(3)
                .ToListAsync();

            return topPerformingBarbers;              
        }
    }
}
