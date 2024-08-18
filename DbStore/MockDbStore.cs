using System;
using test_dotnet_app.Entities;

namespace test_dotnet_app.DbStore;

public class MockDbStore : IMockDbStore
{
    public List<Employee>? Employees { get; set; }
    public List<Department>? Departments { get; set; }

    public MockDbStore()
    {
        Departments = new List<Department>();
        // Departments AddRange
        Employees = new List<Employee>();

        // Populate your mock data here
        // Example:
        Departments.Add(new Department { Id = 1, Name = "Sales" });
        Departments.Add(new Department { Id = 2, Name = "Marketing" });
        Departments.Add(new Department { Id = 3, Name = "Engineering" });
        Departments.Add(new Department { Id = 4, Name = "Finance" });
        Departments.Add(new Department { Id = 5, Name = "HR" });
        Departments.Add(new Department { Id = 6, Name = "IT" });
        Departments.Add(new Department { Id = 7, Name = "Operations" });
        Departments.Add(new Department { Id = 8, Name = "Product Management" });
        Departments.Add(new Department { Id = 9, Name = "Quality Assurance" });
        Departments.Add(new Department { Id = 10, Name = "R&D" });
        Departments.Add(new Department { Id = 11, Name = "Sales Support" });
        Departments.Add(new Department { Id = 12, Name = "Training & Development" });
        Employees.Add(new Employee { Id = 1, FirstName = "John", LastName = "Doe", DepartmentId = 1 });
        Employees.Add(new Employee { Id = 2, FirstName = "Jane", LastName = "Smith", DepartmentId = 2 });
        Employees.Add(new Employee { Id = 3, FirstName = "Mike", LastName = "Johnson", DepartmentId = 3 });
        Employees.Add(new Employee { Id = 4, FirstName = "Sarah", LastName = "Wilson", DepartmentId = 4 });
        Employees.Add(new Employee { Id = 5, FirstName = "Michael", LastName = "Davis", DepartmentId = 5 });
        Employees.Add(new Employee { Id = 6, FirstName = "Emily", LastName = "Thompson", DepartmentId = 6 });
        Employees.Add(new Employee { Id = 7, FirstName = "Daniel", LastName = "Brown", DepartmentId = 7 });
        Employees.Add(new Employee { Id = 8, FirstName = "Sarah", LastName = "Evans", DepartmentId = 8 });
    }
    public void LoadEmployeesForDepartment(ref Department? department)
    {
        if (department != null)
        {
            var id = department?.Id;
            department!.Employees = Employees?.Where(e => e.DepartmentId == id).ToList() ?? new();
        }
    }
    public void LoadDepartmentForEmployee(ref Employee? employee)
    {
        if (employee != null)
        {
            var id = employee?.DepartmentId;
            employee!.Department = Departments?.FirstOrDefault(d => d.Id == id);
        }
    }
}
