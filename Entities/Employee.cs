using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_dotnet_app.Entities;

public class Employee : BaseEntity
{
    [Column("EmployeeId")]
    [Key]
    public int Id { get; set; }

    [Column(TypeName ="nvarchar(50)")]
    [Required(ErrorMessage = "First Name is required")]
    [MinLength(3, ErrorMessage = "First Name should be at least 3 characters long")]
    [MaxLength(50, ErrorMessage = "First Name cannot exceed 50 characters")]
    public string? FirstName { get; set; }

    [Column(TypeName ="nvarchar(50)")]
    [Required(ErrorMessage = "Last Name is required")]
    [MinLength(3, ErrorMessage = "Last Name should be at least 3 characters long")]
    [MaxLength(50, ErrorMessage = "Last Name cannot exceed 50 characters")]
    public string? LastName { get; set; }
    // computed property for FullName
    
    [ForeignKey(nameof(Department))]
    public int DepartmentId { get; set; }
    // navigation property for Department
    public Department? Department { get; set; }
}
