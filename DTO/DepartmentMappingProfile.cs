using System;
using AutoMapper;
using test_dotnet_app.Entities;

namespace test_dotnet_app.DTO;

// public class DepartmentMappingProfile: Profile
// {
//     public DepartmentMappingProfile()
//     {
//         CreateMap<Entities.Department, DepartmentDto>()
//             .ForCtorParam("id", opt=>opt.MapFrom(src=>src.Id))
//             .ForCtorParam("name", opt=>opt.MapFrom(src=>src.Name))
//             .ForCtorParam("employees", opt=>opt.MapFrom(src=>src.Employees))
//             .ForCtorParam("createdAt", opt => opt.MapFrom(src => src.CreatedAt.ToUniversalTime()))
//             .ForCtorParam("updatedAt", opt => opt.MapFrom(src => src.UpdatedAt.ToUniversalTime()));

//         CreateMap<DepartmentDto, Entities.Department>()
//             .ForMember("CreatedAt", opt => opt.MapFrom(src => DateTime.UtcNow))
//             .ForMember("UpdatedAt", opt => opt.MapFrom(src => DateTime.UtcNow));
//     }
// }

public static class DepartmentMappingProfile
{
    public static Department MapFrom(this DepartmentDto departmentDto)
    {
        return new Department
        {
            Id = departmentDto.Id,
            Name = departmentDto.Name,
            Employees = departmentDto.Employees!.Select(emp => emp.MapFrom()).ToList(),
            CreatedAt = departmentDto.CreatedAt.ToUniversalTime(),
            UpdatedAt = departmentDto.UpdatedAt.ToUniversalTime()
        };
    }

    public static IEnumerable<Department> MapFrom(this IEnumerable<DepartmentDto> departmentDtos)
    {
        return departmentDtos.Select(MapFrom);
    }

    public static DepartmentDto MapTo(this Department department)
    {
        return new DepartmentDto
        {
            Id = department.Id,
            Name = department.Name,
            Employees = department.Employees!.Select(emp => emp.MapTo()).ToList(),
            CreatedAt = department.CreatedAt.ToUniversalTime(),
            UpdatedAt = department.UpdatedAt.ToUniversalTime()
        };
    }

    public static IEnumerable<DepartmentDto> MapTo(this IEnumerable<Department> departments)
    {
        return departments.Select(MapTo);
    }
}