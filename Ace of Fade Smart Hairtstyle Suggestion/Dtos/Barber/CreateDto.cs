using System.ComponentModel.DataAnnotations;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.Barber
{
    public class CreateDto
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
