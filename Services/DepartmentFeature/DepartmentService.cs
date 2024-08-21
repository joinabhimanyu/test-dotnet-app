using System;
using test_dotnet_app.DTO;
using test_dotnet_app.Entities;
using test_dotnet_app.Repositories.DepartmentFeature;

namespace test_dotnet_app.Services.DepartmentFeature;

public class DepartmentService: IDepartmentService
{
    private readonly ILogger<DepartmentService> _logger;
    private readonly IDepartmentRepository _repository;
    public DepartmentService(ILogger<DepartmentService> logger, IDepartmentRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public async Task<IEnumerable<Department>> GetAllAsync(bool include)
    {
        return await _repository.GetAllAsync(include);
    }

    public async Task<Department?> GetByIdAsync(int id, bool include)
    {
        return await _repository.GetByIdAsync(id, include);
    }

    public async Task<List<Department>?> SearchAsync(List<SearchParam>? searchParams, bool include)
    {
        return await _repository.SearchAsync(searchParams, include);
    }

    public async Task AddAsync(Department department)
    {
        await _repository.AddAsync(department);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task UpdateAsync(Department department)
    {
        await _repository.UpdateAsync(department);
    }
}
