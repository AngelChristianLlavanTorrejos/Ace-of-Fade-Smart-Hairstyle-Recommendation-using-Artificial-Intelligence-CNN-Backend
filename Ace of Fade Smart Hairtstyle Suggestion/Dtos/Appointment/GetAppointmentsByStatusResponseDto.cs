namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.Appointment
{
    public class GetAppointmentsByStatusResponseDto
    {
        public int Id { get; set; }
        public string? ClientName { get; set; }
        public string? BarberName { get; set; }
        public string? Status { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly TimeIn { get; set; }
        public TimeOnly TimeOut { get; set; }
        public string? Message { get; set; }
        public string? Haircut { get; set; }
    }
}
