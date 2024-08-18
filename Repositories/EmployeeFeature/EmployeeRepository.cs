using System;
using System.Linq.Expressions;
using test_dotnet_app.DbStore;
using test_dotnet_app.DTO;
using test_dotnet_app.Entities;
using test_dotnet_app.Utils;

namespace test_dotnet_app.Repositories.EmployeeFeature;

public class EmployeeRepository : IEmployeeRepository
{
    private IMockDbStore _dbStore;

    public EmployeeRepository(IMockDbStore dbStore)
    {
        _dbStore = dbStore;
    }

    public Task<List<Employee>> GetAllAsync(bool include)
    {
        var employees = _dbStore.Employees ?? new();
        if (include)
        {
            employees.ForEach((employee) =>
            {
                _dbStore.LoadDepartmentForEmployee(ref employee!);
            });
        }
        return Task.FromResult(employees);
    }

    public Task<Employee?> GetByIdAsync(int id, bool include)
    {
        var employee = _dbStore.Employees?.FirstOrDefault(e => e.Id == id);
        if (employee is null) throw new CustomErrorException((int)CustomErroCodes.EntityNotFoundException, "Employee not found");
        if (include)
        {
            _dbStore.LoadDepartmentForEmployee(ref employee);
        }
        return Task.FromResult(employee);
    }

    public Task<List<Employee>?> SearchAsync(List<SearchParam>? searchParams, bool include)
    {
        var search=searchParams.buildExpression<Employee>();
        var employees = _dbStore.Employees?.Where(search!.Compile()).ToList();
        if (include)
        {
            employees?.ForEach((employee) =>
            {
                _dbStore.LoadDepartmentForEmployee(ref employee!);
            });
        }
        return Task.FromResult(employees);
    }

    public Task AddAsync(Employee employee)
    {
        employee.Id = _dbStore.Departments?.Max(d => d.Id) ?? 0 + 1;
        employee.CreatedAt = DateTime.Now;
        employee.UpdatedAt = DateTime.Now;
        _dbStore.Employees ??= new();
        _dbStore.Employees.Add(employee);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var employee = _dbStore.Employees?.FirstOrDefault(e => e.Id == id);
        if (employee is not null)
        {
            _dbStore.Employees?.Remove(employee);
        }
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Employee employee)
    {
        employee.UpdatedAt = DateTime.Now;
        _dbStore.Employees ??= new();
        var existingEmployee = _dbStore.Employees.FirstOrDefault(e => e.Id == employee.Id);
        if (existingEmployee is not null)
        {
            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.DepartmentId = employee.DepartmentId;
        }
        return Task.CompletedTask;
    }
}
