using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Data;
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
    }
}
