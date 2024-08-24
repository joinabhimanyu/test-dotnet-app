using System;
using AutoMapper;
using test_dotnet_app.Entities;

namespace test_dotnet_app.DTO;

// public class UserMappingProfile : Profile
// {
//     public UserMappingProfile()
//     {
//         CreateMap<Entities.User, UserRegistrationDto>();
//         CreateMap<UserRegistrationDto, Entities.User>();
//     }
// }

public static class UserMappingProfile
{
    public static User MapFrom(this UserRegistrationDto userRegistrationDto)
    {
        return new User
        {
            FirstName = userRegistrationDto.FirstName,
            LastName = userRegistrationDto.LastName,
            UserName = userRegistrationDto.UserName,
            Email = userRegistrationDto.Email,
            PhoneNumber = userRegistrationDto.PhoneNumber,
            DateOfBirth = userRegistrationDto.DateOfBirth,
            Address = userRegistrationDto.Address,
            AvatarUrl = userRegistrationDto.AvatarUrl,
            ResetPasswordToken = userRegistrationDto.ResetPasswordToken,
            ResetPasswordTokenExpiration = userRegistrationDto.ResetPasswordTokenExpiration,
        };
    }

    public static UserRegistrationDto MapTo(this User user)
    {
        return new UserRegistrationDto
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            UserName = user.UserName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            DateOfBirth = user.DateOfBirth,
            Address = user.Address,
            AvatarUrl = user.AvatarUrl,
            ResetPasswordToken = user.ResetPasswordToken,
            ResetPasswordTokenExpiration = user.ResetPasswordTokenExpiration,
        };
    }
}
