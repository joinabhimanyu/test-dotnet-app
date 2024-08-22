using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    private EntityDbContext _dbContext;

    public DepartmentRepository(IMockDbStore dbStore)
    {
        _dbStore = dbStore;
        _dbContext = new EntityDbContext();
    }

    public Task<IEnumerable<Department>> GetAllAsync(bool include)
    {
        IEnumerable<Department> departments;
        if (include)
        {
            departments = _dbContext.Departments
                // tell child entities to ignore its children
                .IgnoreAutoIncludes()
                .Include(a => a.Employees)
                .OrderByDescending(b => b.Id)
                .ToList();
        }
        else
        {
            departments = _dbContext.Departments.IgnoreAutoIncludes().OrderByDescending(b => b.Id).ToList();
        }
        return Task.FromResult(departments);
    }

    public Task<Department?> GetByIdAsync(int id, bool include)
    {
        Department? department=null;
        if (include)
        {
            department = _dbContext.Departments.IgnoreAutoIncludes().Include(a=>a.Employees)?.FirstOrDefault(d => d.Id == id);
        }
        else
        {
            department = _dbContext.Departments.IgnoreAutoIncludes().FirstOrDefault(d => d.Id == id);
        }
        
        if (department is null) throw new CustomErrorException((int)CustomErroCodes.EntityNotFoundException, "Department not found");
        return Task.FromResult(department);
    }

    public Task<IEnumerable<Department>?> SearchAsync(List<SearchParam>? searchParams, bool include)
    {
        var search = searchParams.buildExpression<Department>();
        IEnumerable<Department>? departments = null;
        if (include)
        {
            departments = _dbContext.Departments?.IgnoreAutoIncludes().Include(a=>a.Employees).Where(search!.Compile()).ToList();
        }
        else
        {
            departments = _dbContext.Departments?.IgnoreAutoIncludes().Where(search!.Compile()).ToList();
        }
        
        return Task.FromResult(departments);
    }

    public Task AddAsync(Department department)
    {
        // department.Id = _dbStore.Departments?.Max(d => d.Id) ?? 0 + 1;
        var maxid = _dbContext.Departments.OrderByDescending(item => item.Id).Select(a => a.Id).FirstOrDefault();
        if (maxid > 0)
        {
            department.Id = Convert.ToInt32(maxid) + 1;
        }
        else
        {
            department.Id = 1;
        }
        department.CreatedAt = DateTime.Now;
        department.UpdatedAt = DateTime.Now;
        // _dbStore.Departments ??= new();
        // _dbStore.Departments.Add(department);
        _dbContext.Departments!.Add(department);
        _dbContext.SaveChanges();

        return Task.CompletedTask;
    }

    public Task UpdateAsync(Department department)
    {
        department.UpdatedAt = DateTime.Now;
        var existingDepartment = _dbContext.Departments?.FirstOrDefault(d => d.Id == department.Id);
        if (existingDepartment != null)
        {
            existingDepartment.Name = department.Name;
            existingDepartment.UpdatedAt = DateTime.Now;
            
            _dbContext.Update(existingDepartment);
            _dbContext.SaveChanges();
        }
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var departmentToRemove = _dbContext.Departments?.FirstOrDefault(d => d.Id == id);
        if (departmentToRemove != null)
        {
            _dbContext.Departments?.Remove(departmentToRemove);
            _dbContext.SaveChanges();
        }
        return Task.CompletedTask;
    }
}
