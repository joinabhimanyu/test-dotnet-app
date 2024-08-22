using System;
using AutoMapper;
using test_dotnet_app.DTO;
using test_dotnet_app.Entities;
using test_dotnet_app.Repositories.EmployeeFeature;

namespace test_dotnet_app.Services.EmployeeFeature;

public class EmployeeService : IEmployeeService
{
    private readonly ILogger<EmployeeService> _logger;
    private readonly IMapper _mapper;
    private readonly IEmployeeRepository _repository;

    public EmployeeService(ILogger<EmployeeService> logger, IEmployeeRepository repository, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IEnumerable<EmployeeDto>> GetAllAsync(bool include)
    {
        var employees = await _repository.GetAllAsync(include);
        var employeesDto=_mapper.Map<IEnumerable<EmployeeDto>>(employees);
        return employeesDto;
    }

    public async Task<EmployeeDto?> GetByIdAsync(int id, bool include)
    {
        var employee = await _repository.GetByIdAsync(id, include);
        var result=_mapper.Map<EmployeeDto>(employee);
        return result;
    }

    public async Task<IEnumerable<EmployeeDto>?> SearchAsync(List<SearchParam>? searchParams, bool include)
    {
        var employees = await _repository.SearchAsync(searchParams, include);
        var result=_mapper.Map<IEnumerable<EmployeeDto>>(employees);
        return result;
    }

    public async Task AddAsync(EmployeeDto employeeDto)
    {
        var employee=_mapper.Map<Employee>(employeeDto);
        await _repository.AddAsync(employee);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task UpdateAsync(EmployeeDto employeeDto)
    {
        var employee=_mapper.Map<Employee>(employeeDto);
        await _repository.UpdateAsync(employee);
    }
}
