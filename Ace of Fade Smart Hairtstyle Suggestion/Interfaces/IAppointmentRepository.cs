using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.Appointment;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<string> CreateAppointment(int id, CreateAppointmentRequestDto createAppointmentRequestDto);
        Task<List<Appointment>> FetchClientAppointmentsById(int id);
        Task<Appointment?> CancelAppointment(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByStatus(string? status);
        Task<bool> UpdateAppointmentStatus(int id, UpdateAppointmentStatusDto dto);

        Task<int> GetAppointmentsCountToday();
        Task<int> GetPendingAppointmentsCount();
        Task<List<TopHaircutDto>> GetTopHaircut();
        Task<List<Appointment>> FetchBarberAppointmentsById(int id);
    }
}