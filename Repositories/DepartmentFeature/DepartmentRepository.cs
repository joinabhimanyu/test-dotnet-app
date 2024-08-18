using System;
using System.Linq.Expressions;
using test_dotnet_app.DbStore;
using test_dotnet_app.DTO;
using test_dotnet_app.Entities;
using test_dotnet_app.Utils;

namespace test_dotnet_app.Repositories.DepartmentFeature;

public class DepartmentRepository : IDepartmentRepository
{
    private IMockDbStore _dbStore;

    public DepartmentRepository(IMockDbStore dbStore)
    {
        _dbStore = dbStore;
    }

    public Task<List<Department>> GetAllAsync(bool include)
    {
        var departments = _dbStore.Departments ?? new();
        if (include)
        {
            departments.ForEach((department) =>
            {
                _dbStore.LoadEmployeesForDepartment(ref department!);
            });
        }
        return Task.FromResult(departments);
    }

    public Task<Department?> GetByIdAsync(int id, bool include)
    {
        var department = _dbStore.Departments?.FirstOrDefault(d => d.Id == id);
        if (department is null) throw new CustomErrorException((int)CustomErroCodes.EntityNotFoundException, "Department not found");
        if (include)
        {
            _dbStore.LoadEmployeesForDepartment(ref department);
        }
        return Task.FromResult(department);
    }

    public Task<List<Department>?> SearchAsync(List<SearchParam>? searchParams, bool include)
    {
        var search = searchParams.buildExpression<Department>();
        var departments = _dbStore.Departments?.Where(search!.Compile()).ToList();
        if (include)
        {
            departments?.ForEach((department) =>
            {
                _dbStore.LoadEmployeesForDepartment(ref department!);
            });
        }
        return Task.FromResult(departments);
    }

    public Task AddAsync(Department department)
    {
        department.Id = _dbStore.Departments?.Max(d => d.Id) ?? 0 + 1;
        department.CreatedAt = DateTime.Now;
        department.UpdatedAt = DateTime.Now;
        _dbStore.Departments ??= new();
        _dbStore.Departments.Add(department);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Department department)
    {
        department.UpdatedAt = DateTime.Now;
        var existingDepartment = _dbStore.Departments?.FirstOrDefault(d => d.Id == department.Id);
        if (existingDepartment != null)
        {
            existingDepartment.Name = department.Name;
        }
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var departmentToRemove = _dbStore.Departments?.FirstOrDefault(d => d.Id == id);
        if (departmentToRemove != null)
        {
            _dbStore.Departments?.Remove(departmentToRemove);
        }
        return Task.CompletedTask;
    }
}
