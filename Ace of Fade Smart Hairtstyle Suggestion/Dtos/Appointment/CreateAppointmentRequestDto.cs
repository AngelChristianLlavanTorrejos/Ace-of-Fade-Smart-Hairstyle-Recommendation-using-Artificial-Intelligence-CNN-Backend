namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.Appointment
{
    public class CreateAppointmentRequestDto
    {
        public int BarberId { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly TimeIn { get; set; }
        public TimeOnly TimeOut { get; set; }
        public string? Haircut { get; set; }
        public string? Message { get; set; }
    }
}
