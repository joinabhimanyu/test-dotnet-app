using System;
using AutoMapper;

namespace test_dotnet_app.DTO;

public class DepartmentMappingProfile: Profile
{
    public DepartmentMappingProfile()
    {
        CreateMap<Entities.Department, DepartmentDto>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt.ToUniversalTime()))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt.ToUniversalTime()));

        CreateMap<DepartmentDto, Entities.Department>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}
