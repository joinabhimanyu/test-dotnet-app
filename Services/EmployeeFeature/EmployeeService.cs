using System;
using test_dotnet_app.DTO;
using test_dotnet_app.Entities;
using test_dotnet_app.Repositories.EmployeeFeature;

namespace test_dotnet_app.Services.EmployeeFeature;

public class EmployeeService : IEmployeeService
{
    private readonly ILogger<EmployeeService> _logger;
    private readonly IEmployeeRepository _repository;

    public EmployeeService(ILogger<EmployeeService> logger, IEmployeeRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public async Task<List<Employee>> GetAllAsync(bool include)
    {
        return await _repository.GetAllAsync(include);
    }

    public async Task<Employee?> GetByIdAsync(int id, bool include)
    {
        return await _repository.GetByIdAsync(id, include);
    }

    public async Task<List<Employee>?> SearchAsync(List<SearchParam>? searchParams, bool include)
    {
        return await _repository.SearchAsync(searchParams, include);
    }

    public async Task AddAsync(Employee employee)
    {
        await _repository.AddAsync(employee);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task UpdateAsync(Employee employee)
    {
        await _repository.UpdateAsync(employee);
    }
}
