using System;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using test_dotnet_app.DbStore;
using test_dotnet_app.DTO;
using test_dotnet_app.Entities;
using test_dotnet_app.Utils;

namespace test_dotnet_app.Repositories.EmployeeFeature;

public class EmployeeRepository : IEmployeeRepository
{
    private IMockDbStore _dbStore;
    private EntityDbContext _dbContext;

    public EmployeeRepository(IMockDbStore dbStore, EntityDbContext dbContext)
    {
        _dbStore = dbStore;
        _dbContext = dbContext;
    }

    public Task<IEnumerable<Employee>> GetAllAsync(bool include)
    {
        IEnumerable<Employee> employees;
        if (include)
        {
            employees = _dbContext.Employees
                // tell child entities to ignore its children
                .IgnoreAutoIncludes()
                .Include(a => a.Department)
                .OrderByDescending(b => b.Id)
                .ToList();
        }
        else
        {
            employees = _dbContext.Employees.IgnoreAutoIncludes().OrderByDescending(b => b.Id).ToList();
        }
        return Task.FromResult(employees);
    }

    public Task<Employee> GetByIdAsync(int id, bool include)
    {
        Employee? employee = null;
        if (include)
        {
            employee = _dbContext.Employees?.IgnoreAutoIncludes().Include(a=>a.Department).FirstOrDefault(e => e.Id == id);
        }
        else
        {
            employee = _dbContext.Employees?.IgnoreAutoIncludes().FirstOrDefault(e => e.Id == id);
        }
        if (employee is null) throw new CustomErrorException((int)CustomErroCodes.EntityNotFoundException, "Employee not found");
        
        return Task.FromResult(employee);
    }

    public Task<IEnumerable<Employee>?> SearchAsync(List<SearchParam>? searchParams, bool include)
    {
        var search = searchParams.buildExpression<Employee>();
        IEnumerable<Employee>? employees = null;
        if (include)
        {
            employees = _dbContext.Employees?.IgnoreAutoIncludes().Include(a=>a.Department).Where(search!.Compile()).ToList();
        }
        else
        {
            employees = _dbContext.Employees?.IgnoreAutoIncludes().Where(search!.Compile()).ToList();
        }
        return Task.FromResult(employees);
    }

    public Task AddAsync(Employee employee)
    {
        // employee.Id = _dbStore.Departments?.Max(d => d.Id) ?? 0 + 1;
        var maxid = _dbContext.Employees.OrderByDescending(item => item.Id).Select(a => a.Id).FirstOrDefault();
        if (maxid > 0)
        {
            employee.Id = Convert.ToInt32(maxid) + 1;
        }
        else
        {
            employee.Id = 1;
        }
        employee.CreatedAt = DateTime.Now;
        employee.UpdatedAt = DateTime.Now;
        _dbContext.Employees.Add(employee);
        _dbContext.SaveChanges();

        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var employee = _dbContext.Employees?.FirstOrDefault(e => e.Id == id);
        if (employee is not null)
        {
            _dbContext.Employees?.Remove(employee);
            _dbContext.SaveChanges();
        }
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Employee employee)
    {
        var existingEmployee = _dbContext.Employees.FirstOrDefault(e => e.Id == employee.Id);
        if (existingEmployee is not null)
        {
            existingEmployee.FirstName=employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.DepartmentId=employee.DepartmentId;
            
            existingEmployee.UpdatedAt = DateTime.Now;
            _dbContext.Employees.Update(existingEmployee);
            _dbContext.SaveChanges();
        }
        return Task.CompletedTask;
    }
}
