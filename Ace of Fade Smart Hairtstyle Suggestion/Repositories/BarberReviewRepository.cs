using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Data;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.BarberReview;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Interfaces;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;

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

        public async Task<IEnumerable<BarberReview>> GetBarberReviews()
        {
            return await _dbContext.BarberReviews.Where(br => br.Stars != 0).ToListAsync();
        }

        public async Task<List<BarberReview>> GetBarbersToBeReview(int id)
        {
            return await _dbContext.BarberReviews.Where(br => br.Stars == 0 && br.ClientId == id).ToListAsync();
        }

        public async Task<BarberReview?> ReviewBarber(ReviewBarberRequestDto dto)
        {
            var reviewToBeUpdated = await _dbContext.BarberReviews.FirstOrDefaultAsync(br => br.Id == dto.Id);

            if (reviewToBeUpdated == null) return null;

            reviewToBeUpdated.Stars = dto.Stars;
            reviewToBeUpdated.Comments = dto.Comment;

            await _dbContext.SaveChangesAsync();

            return reviewToBeUpdated;
        }


    }
}
