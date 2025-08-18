using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.Appointment;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Mapper
{
    public static class AppointmentMapper
    {
        public static FetchClientAppointmentResponse ToFetchClientResponseDto(this Appointment appointment)
        {
            return new FetchClientAppointmentResponse
            {
                AppointmentId = appointment.Id,
                BarberName = appointment.Barber.Name,
                Date = appointment.Date,
                TimeIn = appointment.TimeIn,
                TimeOut = appointment.TimeOut,
                Status = appointment.Status!.Status
            };
        }

        public static GetAppointmentsByStatusResponseDto ToGetAppointmentsByStatusResponseDto(this Appointment appointment)
        {
            return new GetAppointmentsByStatusResponseDto
            {
                Id = appointment.Id,
                ClientName = appointment.Client.FirstName + " " +
                (string.IsNullOrEmpty(appointment.Client.MiddleName) ? "" : appointment.Client.MiddleName + " ") +
                appointment.Client.LastName,
                BarberName = appointment.Barber.Name,
                Status = appointment.Status!.Status,
                Date = appointment.Date,
                TimeIn = appointment.TimeIn,
                TimeOut = appointment.TimeOut,
                Message = appointment.Message,
                Haircut = appointment.Haircut
            };
        }
    }
}
