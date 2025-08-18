namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.User
{
    public class UserPersonalInformationResponse
    {
        public int ClientId { get; set; }

        public string Role { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string? MiddleName { get; set; }

        public string LastName { get; set; } = null!;

        public string? Gender { get; set; }

        public DateOnly? Birthdate { get; set; }

        public string? ContactNumber { get; set; }

        public string? Address { get; set; }

        public string Email { get; set; } = null!;

        public DateOnly RegistrationDate { get; set; }
    }
}
