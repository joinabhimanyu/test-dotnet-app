using System;
using System.ComponentModel.DataAnnotations;

namespace test_dotnet_app.DTO;

public class DepartmentDto : BaseDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Department Name is required")]
    public string? Name { get; set; }

    public IEnumerable<EmployeeDto>? Employees { get; set; }

    public DepartmentDto(int id, string name, List<EmployeeDto> employees,DateTime createdAt, DateTime updatedAt) //
        :base(createdAt, updatedAt)
    {
        Id = id;
        Name = name;
        Employees = employees;
    }
}
