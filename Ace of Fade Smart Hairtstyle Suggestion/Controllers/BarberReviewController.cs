using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.BarberReview;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Interfaces;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Mapper;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpGet("GetBarberToBeReview/{id:int}")]
        public async Task<IActionResult> GetBarberToBeReview(int id)
        {
            var barberToBeReview = await _barberReviewRepo.GetBarbersToBeReview(id);
            return Ok(barberToBeReview);
        }

        [HttpPut("ReviewBarber")]
        public async Task<IActionResult> ReviewBarber([FromBody] ReviewBarberRequestDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var toBeReview = await _barberReviewRepo.ReviewBarber(dto);

            if (toBeReview == null) return BadRequest(new { message = "Review Failed" });

            return Ok(new { message = "Review Successful" });
        }

        [HttpGet("GetBarberReviews")]
        public async Task<IActionResult> GetBarberReviews()
        {
            var barberReviews = await _barberReviewRepo.GetBarberReviews();
            return Ok(barberReviews);
        }
    }
}
