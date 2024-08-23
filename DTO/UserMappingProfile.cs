using System;
using AutoMapper;

namespace test_dotnet_app.DTO;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<Entities.User, UserRegistrationDto>();
        CreateMap<UserRegistrationDto, Entities.User>();
    }
}
