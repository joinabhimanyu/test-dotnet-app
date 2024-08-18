using System;

namespace test_dotnet_app.Entities;

public class Department : BaseEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Employee> Employees { get; set; } = new();
}
