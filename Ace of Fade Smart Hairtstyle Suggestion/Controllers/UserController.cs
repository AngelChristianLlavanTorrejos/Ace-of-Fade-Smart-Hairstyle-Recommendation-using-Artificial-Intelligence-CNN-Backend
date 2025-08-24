using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.User;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Interfaces;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Mapper;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateRequestDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _userRepository.IsEmailTakenAsync(dto.Email))
            {
                var errors = new Dictionary<string, string[]>()
                {
                    { "Email", new[] { "Email Is Already Taken" } }
                };

                return ValidationProblem(new ValidationProblemDetails(errors));
            }

            await _userRepository.CreateUserAsync(dto);

            return Ok(new { message = "User Created Successfully" });
        }

        [HttpGet("GetClientInformation")]
        public async Task<IActionResult> GetClientInformation()
        {
            var clients = await _userRepository.GetClientInformationAsync();
            return Ok(clients.Select(u => u.ToUserClientInformationDto()));
        }

        [HttpGet("GetUserWhereRoleIsClient")]
        public async Task<IActionResult> GetUserWhereRoleIsClient(int pageNumber = 1, int pageSize = 10, string? search = null)
        {
            var (totalCount, clients) = await _userRepository.GetUserWhereRoleIsClient(pageNumber, pageSize, search);

            return Ok(new
            {
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Data = clients.Select(c => c.ToUserClientInformationDto())
            });
        }

        [HttpPut("UpdatePersonalInformation/{id:int}")]
        public async Task<IActionResult> UpdateUserInformation(int id, [FromBody] UserUpdateProfileInformation dto)
        {
            var user = await _userRepository.UpdatePersonalInformation(id, dto);

            if (user == null) return NotFound();

            return Ok(new { message = "Update Successful" });
        }

        [HttpGet("GetUserById/{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.FetchUserById(id);

            if (user == null) return NotFound();

            return Ok(user.ToUserPersonalInfoResponse());
        }

        [HttpPut("ChangePassword/{id:int}")]
        public async Task<IActionResult> ChangePassword(int id, ChangePasswordRequestDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var res = await _userRepository.ChangePassword(id, dto);

            if (!res) return BadRequest("Change Password Failed");

            return Ok(new { message = "Change Password Successful" });
        }

        [HttpGet("GetClientsCount")]
        public async Task<IActionResult> GetClientsCount()
        {
            var clientsCount = await _userRepository.GetClientsCount();
            return Ok(clientsCount);
        }

        [HttpGet("GetTopClients")]
        public async Task<IActionResult> GetTopClients()
        {
            var topClients = await _userRepository.GetTopClients();
            return Ok(topClients);
        }
    }
}