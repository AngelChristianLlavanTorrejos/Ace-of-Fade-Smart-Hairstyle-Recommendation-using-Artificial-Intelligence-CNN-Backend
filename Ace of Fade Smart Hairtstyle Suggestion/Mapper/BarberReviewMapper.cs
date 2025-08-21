using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.BarberReview;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Mapper
{
    public static class BarberReviewMapper
    {
        public static BarberReview ToBarberReview(this CreateBarberReviewDto barberReviewDto)
        {
            return new BarberReview
            {
                ClientId = barberReviewDto.ClientId,
                BarberId = barberReviewDto.BarberId,
                Stars = 0,
                Comments = ""
            };
        }
    }
}
