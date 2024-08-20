using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_dotnet_app.Entities;

public class Employee : BaseEntity
{
    // [Column("EmployeeId")]
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    // computed property for FullName
    public string FullName => $"{FirstName} {LastName}";
    
    // [ForeignKey(nameof(Department))]
    public int DepartmentId { get; set; }
    // navigation property for Department
    public Department? Department { get; set; }
}
