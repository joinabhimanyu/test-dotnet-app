using System;
using test_dotnet_app.DTO;
using test_dotnet_app.Entities;

namespace test_dotnet_app.Services.DepartmentFeature;

public interface IDepartmentService
{
    Task<List<Department>> GetAllAsync(bool include);
    Task<Department?> GetByIdAsync(int id, bool include);
    Task<List<Department>?> SearchAsync(List<SearchParam>? searchParams, bool include);
    Task AddAsync(Department department);
    Task DeleteAsync(int id);
    Task UpdateAsync(Department department);
}
