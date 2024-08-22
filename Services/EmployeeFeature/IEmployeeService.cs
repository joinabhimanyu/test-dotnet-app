using System;
using test_dotnet_app.DTO;
using test_dotnet_app.Entities;

namespace test_dotnet_app.Services.EmployeeFeature;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetAllAsync(bool include);
    Task<EmployeeDto?> GetByIdAsync(int id, bool include);
    Task<IEnumerable<EmployeeDto>?> SearchAsync(List<SearchParam>? searchParams, bool include);
    Task AddAsync(EmployeeDto employee);
    Task DeleteAsync(int id);
    Task UpdateAsync(EmployeeDto employee);
}
