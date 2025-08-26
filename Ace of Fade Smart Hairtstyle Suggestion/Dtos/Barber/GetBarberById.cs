using System.ComponentModel.DataAnnotations;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.Barber
{
    public class GetBarberById
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
