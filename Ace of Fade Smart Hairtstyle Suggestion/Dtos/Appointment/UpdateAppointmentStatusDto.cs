using System.ComponentModel.DataAnnotations;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.Appointment
{
    public class UpdateAppointmentStatusDto
    {
        [Required]
        public int StatusId { get; set; }
    }
}
