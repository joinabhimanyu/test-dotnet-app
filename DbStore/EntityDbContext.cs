using System;
using Microsoft.EntityFrameworkCore;
using test_dotnet_app.Entities;

namespace test_dotnet_app.DbStore;

public class EntityDbContext: DbContext
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

        // ignore auto includes in entity
        // modelBuilder.Entity<Department>().Ignore("Employees");
        // modelBuilder.Entity<Employee>().Ignore("Department");
        modelBuilder.Entity<Department>()
            .HasMany(dep=>dep.Employees)
            .WithOne(emp=>emp.Department)
            .HasForeignKey(emp=>emp.DepartmentId)
            .IsRequired();

        modelBuilder.Entity<Employee>()
            .HasOne(emp=>emp.Department)
            .WithMany(dept=>dept.Employees)
            .HasForeignKey(emp=>emp.DepartmentId)
            .IsRequired();

        modelBuilder.Entity<Employee>()
        .Navigation(a=>a.Department)
        .AutoInclude(false);

        modelBuilder.Entity<Department>()
        .Navigation(a=>a.Employees)
        .AutoInclude(false);

        modelBuilder.ApplyConfiguration(new DepartmentEntityConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeEntityConfiguration());
    }
}
