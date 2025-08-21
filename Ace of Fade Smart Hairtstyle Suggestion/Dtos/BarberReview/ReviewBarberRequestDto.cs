using System.ComponentModel.DataAnnotations;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.BarberReview
{
    public class ReviewBarberRequestDto
    {
        public int Id { get; set; }
        [Required]
        public int Stars {  get; set; }
        public string? Comment { get; set; }
    }
}
