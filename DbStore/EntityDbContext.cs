using System;
using Microsoft.EntityFrameworkCore;
using test_dotnet_app.Entities;

namespace test_dotnet_app.DbStore;

public class EntityDbContext: DbContext
{
    public EntityDbContext(DbContextOptions<EntityDbContext> options) : base(options)
    {
    }
    public DbSet<Employee> Employees { get; set; }

    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DepartmentEntityConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeEntityConfiguration());
    }
}
