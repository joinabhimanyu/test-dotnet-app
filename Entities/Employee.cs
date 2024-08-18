using System;

namespace test_dotnet_app.Entities;

public class Employee : BaseEntity
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    // computed property for FullName
    public string FullName => $"{FirstName} {LastName}";
    public int DepartmentId { get; set; }
    // navigation property for Department
    public Department? Department { get; set; }
}
