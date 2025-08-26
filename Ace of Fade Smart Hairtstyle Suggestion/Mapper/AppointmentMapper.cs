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
                ClientId = appointment.ClientId,
                BarberId = appointment.BarberId,
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

        public static FetchBarberAppointmentsByIdDto ToBarberAppointmentsByIdDto (this Appointment model)
        {
            return new FetchBarberAppointmentsByIdDto
            {
                Id = model.Id,
                Status = model.Status.Status,
                ClientName = model.Client.FirstName + " " +
                (!string.IsNullOrEmpty(model.Client.MiddleName) ? model.Client.MiddleName + " " : " ") +
                model.Client.LastName,
                Date = model.Date,
                TimeIn = model.TimeIn,
                TimeOut = model.TimeOut,
                Haircut = model.Haircut ?? "",
                Message = model.Message ?? "",
                CreatedAt = model.CreatedAt
            };
        }
    }
}
