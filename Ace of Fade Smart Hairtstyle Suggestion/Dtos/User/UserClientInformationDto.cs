namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.User
{
    public class UserClientInformationDto
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public DateOnly RegistrationDate { get; set; }
    }
}
