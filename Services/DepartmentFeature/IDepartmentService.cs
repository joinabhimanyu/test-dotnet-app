using System;
using test_dotnet_app.DTO;
using test_dotnet_app.Entities;

namespace test_dotnet_app.Services.DepartmentFeature;

public interface IDepartmentService
{
    Task<IEnumerable<DepartmentDto>> GetAllAsync(bool include);
    Task<DepartmentDto?> GetByIdAsync(int id, bool include);
    Task<IEnumerable<DepartmentDto>?> SearchAsync(List<SearchParam>? searchParams, bool include);
    Task AddAsync(DepartmentDto department);
    Task DeleteAsync(int id);
    Task UpdateAsync(DepartmentDto department);
}
