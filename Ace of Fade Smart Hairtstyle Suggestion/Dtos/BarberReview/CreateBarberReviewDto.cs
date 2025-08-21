using System.ComponentModel.DataAnnotations;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.BarberReview
{
    public class CreateBarberReviewDto
    {
        [Required]
        public int ClientId { get; set; }
        [Required]
        public int BarberId { get; set; }
    }
}
