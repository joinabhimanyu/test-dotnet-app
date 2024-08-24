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
    
    [Required(ErrorMessage ="Department is required")]
    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public EmployeeDto()
    {
    }
    public EmployeeDto(int id, string firstName, string lastName, string fullName, int departmentId, string departmentName
        , DateTime createdAt, DateTime updatedAt)
    : base(createdAt, updatedAt) 
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        FullName=fullName;
        DepartmentId = departmentId;
        DepartmentName=departmentName;
    }
}
