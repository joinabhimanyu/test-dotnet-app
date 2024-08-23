using System;
using Microsoft.EntityFrameworkCore;
using test_dotnet_app.DbStore;

namespace test_dotnet_app.Extensions;

public static class ConfigureDbStoreWrapper
{
    public static void ConfigureDbStore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IMockDbStore>(new MockDbStore());
        services.AddDbContext<EntityDbContext>((options) =>
        {
            options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;");
            // options.UseInMemoryDatabase("EmployeeDB");
           // options.UseSqlServer(configuration.GetConnectionString("sqlConnection"))
        });

    }
}
