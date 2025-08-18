using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.Barber;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Mapper
{
    public static class BarberMapper
    {
        public static GetBarberResponseDto ToGetBarberResponseDto (this Barber barber)
        {
            return new GetBarberResponseDto
            {
                Id = barber.Id,
                Name = barber.Name,
            };
        }
    }
}
