using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.BarberReview;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Interfaces;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BarberReviewController : Controller
    {
        private readonly IBarberReviewRepository _barberReviewRepo;

        public BarberReviewController(IBarberReviewRepository barberReviewRepo)
        {
            _barberReviewRepo = barberReviewRepo;
        }

        [HttpPost("CreateBarberReview")]
        public async Task<IActionResult> CreateBarberReview([FromBody] CreateBarberReviewDto createDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newBarberToReview = createDto.ToBarberReview();

            var barberReview = await _barberReviewRepo.CreateReview(newBarberToReview);

            return Ok(barberReview);
        }
    }
}
