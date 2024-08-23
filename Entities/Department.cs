using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_dotnet_app.Entities;

public class Department : BaseEntity
{
    [Column("DepartmentId")]
    [Key]
    public int Id { get; set; }

    [Column(TypeName ="nvarchar(50)")]
    [Required(ErrorMessage = "Name is required")]
    [MinLength(3, ErrorMessage = "Name should be at least 3 characters long")]
    [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
    // column type nvarchar(50) in ef core
    public string? Name { get; set; }

    public ICollection<Employee>? Employees { get; set; }=new List<Employee>();
}
