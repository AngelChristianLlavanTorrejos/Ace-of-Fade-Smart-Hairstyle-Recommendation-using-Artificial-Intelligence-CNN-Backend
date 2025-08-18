namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.Appointment
{
    public class FetchClientAppointmentResponse
    {
        public int AppointmentId { get; set; }
        public string? BarberName { get; set; }
        public DateOnly Date {  get; set; }
        public TimeOnly TimeIn { get; set; }
        public TimeOnly TimeOut { get; set; }
        public string? Status { get; set; }
    }
}
