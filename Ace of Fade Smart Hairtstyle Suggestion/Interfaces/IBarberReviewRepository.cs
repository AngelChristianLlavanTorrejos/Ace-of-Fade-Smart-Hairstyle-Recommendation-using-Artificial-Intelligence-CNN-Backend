using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.BarberReview;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Interfaces
{
    public interface IBarberReviewRepository
    {
        Task<BarberReview> CreateReview(BarberReview barberReview);
    }
}
