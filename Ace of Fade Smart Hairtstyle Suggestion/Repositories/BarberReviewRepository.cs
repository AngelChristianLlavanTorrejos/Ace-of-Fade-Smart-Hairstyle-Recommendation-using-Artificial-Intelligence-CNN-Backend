using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Data;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Interfaces;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;
using Microsoft.EntityFrameworkCore;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Repositories
{
    public class BarberReviewRepository : IBarberReviewRepository
    {
        private readonly SmartHairstyleSuggestionContext _dbContext;

        public BarberReviewRepository(SmartHairstyleSuggestionContext dbContext)
        {   
            _dbContext = dbContext;
        }

        public async Task<BarberReview> CreateReview(BarberReview barberReview)
        {
            _dbContext.BarberReviews.Add(barberReview);
            await _dbContext.SaveChangesAsync();
            return barberReview;
        }
    }
}
