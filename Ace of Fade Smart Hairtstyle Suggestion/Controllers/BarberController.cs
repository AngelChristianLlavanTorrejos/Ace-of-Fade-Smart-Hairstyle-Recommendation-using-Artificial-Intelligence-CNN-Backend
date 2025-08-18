using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.Barber;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Interfaces;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Mapper;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BarberController : Controller
    {
        private readonly IBarberRepository _barberRepository;

        public BarberController(IBarberRepository barberRepository)
        {
            _barberRepository = barberRepository;
        }

        [HttpGet("GetBarbers")]
        public async Task<IActionResult> GetBarber()
        {
            var barbers = await _barberRepository.GetBarbers();
            return Ok(barbers.Select(b => b.ToGetBarberResponseDto()));
        }

        [HttpPost("CreateBarber")]
        public async Task<IActionResult> CreateBarber([FromBody] CreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Barber barber = new Barber
            {
                Name = dto.Name,
            };

            await _barberRepository.CreateBarber(barber);

            return Ok(new { message = "New Barber Created" });
        }
    }
}
