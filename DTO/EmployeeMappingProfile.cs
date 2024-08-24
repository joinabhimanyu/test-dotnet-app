using System;
using AutoMapper;
using test_dotnet_app.Entities;

namespace test_dotnet_app.DTO;

// public class EmployeeMappingProfile : Profile
// {
//     public EmployeeMappingProfile()
//     {
//         CreateMap<Entities.Employee, EmployeeDto>()
//             .ForCtorParam("departmentName", opt => opt.MapFrom(src => src.Department!.Name))
//             .ForCtorParam("fullName", opt => opt.MapFrom(src => src.FirstName + src.LastName))
//             .ForCtorParam("id", opt => opt.MapFrom(src => src.Id))
//             .ForCtorParam("firstName", opt => opt.MapFrom(src => src.FirstName))
//             .ForCtorParam("lastName", opt => opt.MapFrom(src => src.LastName))
//             .ForCtorParam("departmentId", opt => opt.MapFrom(src => src.DepartmentId))
//             .ForCtorParam("createdAt", opt => opt.MapFrom(src => src.CreatedAt.ToUniversalTime()))
//             .ForCtorParam("updatedAt", opt => opt.MapFrom(src => src.UpdatedAt.ToUniversalTime()));

//         CreateMap<EmployeeDto, Entities.Employee>()
//             .ForMember("DepartmentId", opt => opt.MapFrom(src => src.DepartmentId))
//             .ForMember("CreatedAt", opt => opt.MapFrom(src => DateTime.UtcNow))
//             .ForMember("UpdatedAt", opt => opt.MapFrom(src => DateTime.UtcNow));
//     }
// }

public static class EmployeeMappingProfile
{
    public static Employee MapFrom(this EmployeeDto employeeDto)
    {
        return new Employee
        {
            DepartmentId = employeeDto.DepartmentId,
            Id = employeeDto.Id,
            FirstName = employeeDto.FirstName,
            LastName = employeeDto.LastName,
            Department = new Department { Id = employeeDto.DepartmentId, Name = employeeDto.DepartmentName },
            CreatedAt = employeeDto.CreatedAt.ToUniversalTime(),
            UpdatedAt = employeeDto.UpdatedAt.ToUniversalTime()
        };
    }

    public static IEnumerable<Employee> MapFrom(this IEnumerable<EmployeeDto> employeeDtos)
    {
        return employeeDtos.Select(MapFrom);
    }

    public static EmployeeDto MapTo(this Employee employee)
    {
        return new EmployeeDto
        {
            DepartmentId = employee.DepartmentId,
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            DepartmentName = employee.Department?.Name,
            FullName = $"{employee.FirstName} {employee.LastName}",
            CreatedAt = employee.CreatedAt.ToUniversalTime(),
            UpdatedAt = employee.UpdatedAt.ToUniversalTime()
        };
    }

    public static IEnumerable<EmployeeDto> MapTo(this IEnumerable<Employee> employees)
    {
        return employees.Select(MapTo);
    }
}
