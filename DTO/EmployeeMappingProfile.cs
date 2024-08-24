using System;
using AutoMapper;

namespace test_dotnet_app.DTO;

public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<Entities.Employee, EmployeeDto>()
            .ForCtorParam("departmentName", opt => opt.MapFrom(src => src.Department!.Name))
            .ForCtorParam("fullName", opt => opt.MapFrom(src => src.FirstName + src.LastName))
            .ForCtorParam("id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("firstName", opt => opt.MapFrom(src => src.FirstName))
            .ForCtorParam("lastName", opt => opt.MapFrom(src => src.LastName))
            .ForCtorParam("departmentId", opt => opt.MapFrom(src => src.DepartmentId))
            .ForCtorParam("createdAt", opt => opt.MapFrom(src => src.CreatedAt.ToUniversalTime()))
            .ForCtorParam("updatedAt", opt => opt.MapFrom(src => src.UpdatedAt.ToUniversalTime()));

        CreateMap<EmployeeDto, Entities.Employee>()
            .ForMember("DepartmentId", opt => opt.MapFrom(src => src.DepartmentId))
            .ForMember("CreatedAt", opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember("UpdatedAt", opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}
