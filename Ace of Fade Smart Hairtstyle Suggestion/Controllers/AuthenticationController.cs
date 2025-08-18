using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.Authentication;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Interfaces;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Mapper;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IUserRepository _userRepository;

        public AuthenticationController(IAuthenticationRepository authenticationRepository, IUserRepository userRepository)
        {
            _authenticationRepository = authenticationRepository;
            _userRepository = userRepository;
        }

        [HttpPost("IsAuthenticated")]
        public async Task<IActionResult> IsAuthenticated([FromBody] AuthenticationRequestDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _authenticationRepository.IsAuthenticatedAsync(dto);

            if (!result) return Unauthorized();

            var authenticatedUser = await _userRepository.GetUserByEmailAsync(dto.Email);

            if (authenticatedUser == null) return NotFound();

            return Ok(authenticatedUser.ToAuthenticationResponseDto());
        }
    }
}
