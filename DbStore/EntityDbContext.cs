using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using test_dotnet_app.Entities;

namespace test_dotnet_app.DbStore;

public class EntityDbContext: IdentityDbContext<User>
{
    public EntityDbContext(DbContextOptions<EntityDbContext> options) : base(options)
    {
        // Database.EnsureCreated();
        // check if index exists in sql server database
        
        // Database.ExecuteSqlRaw("CREATE INDEX IX_Employees_DepartmentId ON Employees (DepartmentId) with (drop_existing = on)");
        // Database.ExecuteSqlRaw("CREATE INDEX IX_Departments_Name ON Departments (Name) with (drop_existing = on)");
        // Database.ExecuteSqlRaw("CREATE INDEX IX_Departments_CreatedAt ON Departments (CreatedAt) with (drop_existing = on)");
        // Database.ExecuteSqlRaw("CREATE INDEX IX_Departments_UpdatedAt ON Departments (UpdatedAt) with (drop_existing = on)");
        // Database.ExecuteSqlRaw("CREATE INDEX IX_Employees_FirstName ON Employees (FirstName) with (drop_existing = on)");
        // Database.ExecuteSqlRaw("CREATE INDEX IX_Employees_LastName ON Employees (LastName) with (drop_existing = on)");
        // Database.ExecuteSqlRaw("CREATE INDEX IX_Employees_CreatedAt ON Employees (CreatedAt) with (drop_existing = on)");
        // Database.ExecuteSqlRaw("CREATE INDEX IX_Employees_UpdatedAt ON Employees (UpdatedAt) with (drop_existing = on)");
    }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Department> Departments { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseInMemoryDatabase("EmployeeDB");
    //     base.OnConfiguring(optionsBuilder);
    // }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureDocumentEntityRelations();
        modelBuilder.ConfigureEmployeeEntityRelations();
        modelBuilder.ApplyConfiguration(new DepartmentEntityConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeEntityConfiguration());
        modelBuilder.ApplyConfiguration(new IdentityRoleEntityConfiguration());
    }
}
