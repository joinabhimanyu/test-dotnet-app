using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using test_dotnet_app.Entities;

namespace test_dotnet_app.DbStore;

public class DepartmentEntityConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        // seed department data
        builder.HasData(
            new Department { Id = 1, Name = "Sales" },
            new Department { Id = 2, Name = "Marketing" },
            new Department { Id = 3, Name = "Engineering" },
            new Department { Id = 4, Name = "Finance" },
            new Department { Id = 5, Name = "HR" },
            new Department { Id = 6, Name = "IT" },
            new Department { Id = 7, Name = "Operations" },
            new Department { Id = 8, Name = "Product Management" },
            new Department { Id = 9, Name = "Quality Assurance" },
            new Department { Id = 10, Name = "R&D" },
            new Department { Id = 11, Name = "Sales Support" },
            new Department { Id = 12, Name = "Training & Development" }
        );
    }
}
