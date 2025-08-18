using System.ComponentModel.DataAnnotations;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.User
{
    public class ChangePasswordRequestDto
    {
        [Required(ErrorMessage = "Enter Current Password")]
        public string CurrentPassword { get; set; } = null!;
        [Required(ErrorMessage = "Enter New Password")]
        public string NewPassword { get; set; } = null!;
        [Required(ErrorMessage = "Enter Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "Password Does Not Match")]
        public string ConfirmPassword { get; set; } = null!;
    }
}