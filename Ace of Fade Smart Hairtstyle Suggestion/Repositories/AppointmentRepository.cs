using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Data;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.Appointment;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Interfaces;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly SmartHairstyleSuggestionContext _context;

        public AppointmentRepository(SmartHairstyleSuggestionContext context)
        {
            _context = context;
        }

        public async Task<string> CreateAppointment(int id,CreateAppointmentRequestDto createAppointmentRequestDto)
        {
            using var connection = _context.Database.GetDbConnection();
            await connection.OpenAsync();

            using var command = connection.CreateCommand();

            command.CommandText = "CreateAppointment";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@ClientId", id));
            command.Parameters.Add(new SqlParameter("@BarberId", createAppointmentRequestDto.BarberId));
            command.Parameters.Add(new SqlParameter("@Date", createAppointmentRequestDto.Date));
            command.Parameters.Add(new SqlParameter("@TimeIn", createAppointmentRequestDto.TimeIn));
            command.Parameters.Add(new SqlParameter("@TimeOut", createAppointmentRequestDto.TimeOut));
            command.Parameters.Add(new SqlParameter("@Message", createAppointmentRequestDto.Message ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@Haircut", createAppointmentRequestDto.Haircut ?? (object)DBNull.Value));

            var outputParameter = new SqlParameter("@Result", SqlDbType.NVarChar, 255)
            {
                Direction = ParameterDirection.Output
            };

            command.Parameters.Add(outputParameter);

            await command.ExecuteNonQueryAsync();

            return outputParameter.Value!.ToString() ?? string.Empty;
        }

        public async Task<List<Appointment>> FetchClientAppointmentsById(int id)
        {
            return await _context.Appointments.Include(a => a.Barber)
                    .Include(a => a.Status)
                    .Where(a => a.ClientId == id)
                    .OrderBy(a => a.Date)
                    .ToListAsync();
        }

        public async Task<Appointment?> CancelAppointment(int id)
        {
            var appointmentToBeCanceled = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == id);

            if (appointmentToBeCanceled == null) return null;

            appointmentToBeCanceled.StatusId = 5;

            await _context.SaveChangesAsync();

            return appointmentToBeCanceled;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByStatus(string? status)
        {
            var query = _context.Appointments.AsQueryable();

            query = query.Include(appointment => appointment.Client)
                    .Include(appointment => appointment.Barber)
                    .Include(appointment => appointment.Status);

            if (!string.IsNullOrEmpty(status))
            {
                query.Where(appointment => appointment.Status.Status == status);
            }

            return await query.ToListAsync();
        }
    }
}
