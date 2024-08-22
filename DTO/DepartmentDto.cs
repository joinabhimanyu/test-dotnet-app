using System;
using System.ComponentModel.DataAnnotations;

namespace test_dotnet_app.DTO;

public class DepartmentDto : BaseDto
{
    public int DepartmentId { get; set; }

    [Required(ErrorMessage = "Department Name is required")]
    public string? Name { get; set; }

    public IEnumerable<EmployeeDto>? Employees { get; set; }
}
