using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using test_dotnet_app.Entities;

namespace test_dotnet_app.DbStore;

public class EmployeeEntityConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasData(
            new Employee { Id = 1, FirstName = "John", LastName = "Doe", DepartmentId = 1 },
            new Employee { Id = 2, FirstName = "Jane", LastName = "Smith", DepartmentId = 2 },
            new Employee { Id = 3, FirstName = "Mike", LastName = "Johnson", DepartmentId = 3 },
            new Employee { Id = 4, FirstName = "Sarah", LastName = "Wilson", DepartmentId = 4 },
            new Employee { Id = 5, FirstName = "Michael", LastName = "Davis", DepartmentId = 5 },
            new Employee { Id = 6, FirstName = "Emily", LastName = "Thompson", DepartmentId = 6 },
            new Employee { Id = 7, FirstName = "Daniel", LastName = "Brown", DepartmentId = 7 },
            new Employee { Id = 8, FirstName = "Sarah", LastName = "Evans", DepartmentId = 8 },
            new Employee { Id = 9, FirstName = "Max", LastName = "Evans", DepartmentId = 9 },
            new Employee { Id = 10, FirstName = "Emily", LastName = "Evans", DepartmentId = 10 },
            new Employee { Id = 11, FirstName = "Micky", LastName = "Evans", DepartmentId = 11 },
            new Employee { Id = 12, FirstName = "Kyle", LastName = "Evans", DepartmentId = 12 }
        );
    }
}
