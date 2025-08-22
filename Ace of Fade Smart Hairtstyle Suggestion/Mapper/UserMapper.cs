using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.Authentication;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Dtos.User;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Mapper
{
    public static class UserMapper
    {
        public static AuthenticationResponseDto ToAuthenticationResponseDto (this User user)
        {
            return new AuthenticationResponseDto()
            {
                IsSuccess = true,
                UserId = user.UserId,
                Role = user.Role,
                Name = user.FirstName + (string.IsNullOrEmpty(user.MiddleName) ? "" : " " + user.MiddleName) + " " + user.LastName
            };
        }

        public static UserClientInformationDto ToUserClientInformationDto(this User user)
        {
            return new UserClientInformationDto()
            {
                UserId = user.UserId,
                Name = user.FirstName + (string.IsNullOrEmpty(user.MiddleName) ? "" : " " + user.MiddleName) + " " + user.LastName,
                RegistrationDate = user.RegistrationDate
            };
        }

        public static void UpdateUserInformation (this User user, UserUpdateProfileInformation dto)
        {
            user.MiddleName = dto.MiddleName;
            user.Gender = dto.Gender;
            user.Birthdate = dto.Birthdate;
            user.ContactNumber = dto.ContactNumber;
            user.Address = dto.Address;
        }

        public static UserPersonalInformationResponse ToUserPersonalInfoResponse (this User user)
        {
            return new UserPersonalInformationResponse
            {
                UserId = user.UserId,
                Role = user.Role,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Gender = user.Gender,
                Birthdate = user.Birthdate,
                ContactNumber = user.ContactNumber,
                Address = user.Address,
                RegistrationDate = user.RegistrationDate,
                Email = user.Email,
            };
        }
    }
}
