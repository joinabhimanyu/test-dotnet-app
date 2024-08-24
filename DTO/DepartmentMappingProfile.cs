using System;
using AutoMapper;

namespace test_dotnet_app.DTO;

public class DepartmentMappingProfile: Profile
{
    public DepartmentMappingProfile()
    {
        CreateMap<Entities.Department, DepartmentDto>()
            .ForCtorParam("id", opt=>opt.MapFrom(src=>src.Id))
            .ForCtorParam("name", opt=>opt.MapFrom(src=>src.Name))
            .ForCtorParam("employees", opt=>opt.MapFrom(src=>src.Employees))
            .ForCtorParam("createdAt", opt => opt.MapFrom(src => src.CreatedAt.ToUniversalTime()))
            .ForCtorParam("updatedAt", opt => opt.MapFrom(src => src.UpdatedAt.ToUniversalTime()));

        CreateMap<DepartmentDto, Entities.Department>()
            .ForMember("CreatedAt", opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember("UpdatedAt", opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}
