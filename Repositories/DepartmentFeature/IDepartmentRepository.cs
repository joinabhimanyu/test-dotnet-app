using System;
using System.Linq.Expressions;
using test_dotnet_app.DTO;
using test_dotnet_app.Entities;

namespace test_dotnet_app.Repositories.DepartmentFeature;

public interface IDepartmentRepository
{
    Task<IEnumerable<Department>> GetAllAsync(bool include);
    Task<Department?> GetByIdAsync(int id, bool include);
    Task<List<Department>?> SearchAsync(List<SearchParam>? searchParams, bool include);
    Task AddAsync(Department department);
    Task UpdateAsync(Department department);
    Task DeleteAsync(int id);
}
