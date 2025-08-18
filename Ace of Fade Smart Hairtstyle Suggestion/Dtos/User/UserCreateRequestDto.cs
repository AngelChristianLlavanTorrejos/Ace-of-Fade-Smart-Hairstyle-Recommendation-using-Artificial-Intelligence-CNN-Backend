using System.ComponentModel.DataAnnotations;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.User
{
    public class UserCreateRequestDto
    {
        [Required(ErrorMessage = "Role Is Required")]
        public string Role { get; set; } = null!;
        [Required(ErrorMessage = "First Name Is Required")]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "First Name Can Only Contain Letters, Spaces, Apostrophes, and Hyphens.")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "Last Name Is Required")]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "First Name Can Only Contain Letters, Spaces, Apostrophes, and Hyphens.")]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Password Is Required")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Password Must Be Atleast 10 Characters")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "Confirm Password Is Required")]
        [Compare("Password", ErrorMessage = "Password Doest Not Match")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
