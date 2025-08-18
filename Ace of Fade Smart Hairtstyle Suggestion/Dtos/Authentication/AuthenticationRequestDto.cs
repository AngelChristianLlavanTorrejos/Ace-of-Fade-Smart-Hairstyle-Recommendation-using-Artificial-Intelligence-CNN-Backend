
using System.ComponentModel.DataAnnotations;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.Authentication
{
    public class AuthenticationRequestDto
    {
        [Required(ErrorMessage = "Email Is Required")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; } = null!;
    }
}