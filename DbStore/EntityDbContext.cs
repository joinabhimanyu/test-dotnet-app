using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using test_dotnet_app.Entities;

namespace test_dotnet_app.DbStore;

public class EntityDbContext: IdentityDbContext<User>
{
    // public EntityDbContext(DbContextOptions<EntityDbContext> options) : base(options)
    // {
    // }
    public EntityDbContext()
    {  
        Database.EnsureCreated();
        // Database.ExecuteSqlRaw("CREATE INDEX IX_Employees_DepartmentId ON Employees (DepartmentId)");
        // Database.ExecuteSqlRaw("CREATE INDEX IX_Departments_Name ON Departments (Name)");
        // Database.ExecuteSqlRaw("CREATE INDEX IX_Departments_CreatedAt ON Departments (CreatedAt)");
        // Database.ExecuteSqlRaw("CREATE INDEX IX_Departments_UpdatedAt ON Departments (UpdatedAt)");
        // Database.ExecuteSqlRaw("CREATE INDEX IX_Employees_FirstName ON Employees (FirstName)");
        // Database.ExecuteSqlRaw("CREATE INDEX IX_Employees_LastName ON Employees (LastName)");
        // Database.ExecuteSqlRaw("CREATE INDEX IX_Employees_CreatedAt ON Employees (CreatedAt)");
        // Database.ExecuteSqlRaw("CREATE INDEX IX_Employees_UpdatedAt ON Employees (UpdatedAt)");
     }
    public DbSet<Employee> Employees { get; set; }

    public DbSet<Department> Departments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("EmployeeDB");
        // UseSqlServer(configuration.GetConnectionString("sqlConnection"))
        // UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=TestDb;Integrated Security=True")
        base.OnConfiguring(optionsBuilder);
    }
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
