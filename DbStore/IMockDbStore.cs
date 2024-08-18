using System;
using test_dotnet_app.Entities;

namespace test_dotnet_app.DbStore;

public interface IMockDbStore
{
    public List<Employee>? Employees { get; set; }
    public List<Department>? Departments { get; set; }
    void LoadEmployeesForDepartment(ref Department? department);
    void LoadDepartmentForEmployee(ref Employee? employee);
}
