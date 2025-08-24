using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.Appointment;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Interfaces;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        [HttpPost("CreateAppointment/{id:int}")]
        public async Task<IActionResult> CreateAppointment(int id, [FromBody] CreateAppointmentRequestDto createAppointmentRequestDto)
        {
            var message = await _appointmentRepository.CreateAppointment(id, createAppointmentRequestDto);

            if (!message.Equals("Appointment Booking Successful"))
            {
                return BadRequest(new { validationMessage = message });
            }

            return Ok(new { validationMessage = message });
        }

        [HttpGet("FetchClientAppointment/{id:int}")]
        public async Task<IActionResult> FetchClientAppointmentsById(int id)
        {
            var appointments = await _appointmentRepository.FetchClientAppointmentsById(id);

            return Ok(appointments.Select(a => a.ToFetchClientResponseDto()));
        }

        [HttpPut("CancelAppointment/{id:int}")]
        public async Task<IActionResult> CancelAppointment(int id)
        {
            var appointmentToBeCanceled = await _appointmentRepository.CancelAppointment(id);

            if (appointmentToBeCanceled == null) return NotFound();

            return Ok(appointmentToBeCanceled);
        }

        [HttpGet("GetAppointmentsByStatus")]
        public async Task<IActionResult> GetAppointmentsByStatus([FromQuery] string? status)
        {
            var appointments = await _appointmentRepository.GetAppointmentsByStatus(status);
            return Ok(appointments.Select(appointment => appointment.ToGetAppointmentsByStatusResponseDto()));
        }

        [HttpPut("UpdateAppointmentStatus/{id:int}")]
        public async Task<IActionResult> UpdateAppointmentStatus (int id, UpdateAppointmentStatusDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var appointmentToBeUpdated = await _appointmentRepository.UpdateAppointmentStatus(id, dto);

            if (!appointmentToBeUpdated) return BadRequest();

            return Ok(new { message = "Update Successful" });
        }

        [HttpGet("GetAppointmentsCountToday")]
        public async Task<IActionResult> GetAppointmentsCountToday()
        {
            var appointmetsCountToday = await _appointmentRepository.GetAppointmentsCountToday();
            return Ok(appointmetsCountToday);
        }

        [HttpGet("GetPendingAppointmentsCount")]
        public async Task<IActionResult> GetPendingAppointmentsCount()
        {
            var pendingAppointmentsCount = await _appointmentRepository.GetPendingAppointmentsCount();
            return Ok(pendingAppointmentsCount);
        }

        [HttpGet("GetTopHaircut")]
        public async Task<IActionResult> GetTopHaircut()
        {
            var topHaircut = await _appointmentRepository.GetTopHaircut();
            return Ok(topHaircut);
        }
    }
}
