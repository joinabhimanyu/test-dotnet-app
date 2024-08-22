using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_dotnet_app.Entities;

public class Department : BaseEntity
{
    [Column("DepartmentId")]
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Employee>? Employees { get; set; }=new List<Employee>();
}
