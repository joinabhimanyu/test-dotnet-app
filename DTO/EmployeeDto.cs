using System;
using System.ComponentModel.DataAnnotations;

namespace test_dotnet_app.DTO;

public class EmployeeDto: BaseDto
{
    public int Id { get; set; }

    [Required(ErrorMessage ="Employeed First Name is required")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage ="Employeed Last Name is required")]
    public string? LastName { get; set; }

    public string? FullName { get; set; }

    public string? DepartmentName { get; set; }
}
