using System;
using test_dotnet_app.DTO;
using test_dotnet_app.Entities;

namespace test_dotnet_app.Services.EmployeeFeature;

public interface IEmployeeService
{
    Task<List<Employee>> GetAllAsync(bool include);
    Task<Employee?> GetByIdAsync(int id, bool include);
    Task<List<Employee>?> SearchAsync(List<SearchParam>? searchParams, bool include);
    Task AddAsync(Employee employee);
    Task DeleteAsync(int id);
    Task UpdateAsync(Employee employee);
}
