using System;
using Microsoft.EntityFrameworkCore;
using test_dotnet_app.DbStore;

namespace test_dotnet_app.Extensions;

public static class ConfigureMockDbStoreWrapper
{
    public static void ConfigureMockDbStore(this IServiceCollection services)
    {
        services.AddSingleton<IMockDbStore>(new MockDbStore());
        services.AddDbContext<EntityDbContext>((options) =>
       {
           options.UseInMemoryDatabase("EmployeeDB");
           // UseSqlServer(configuration.GetConnectionString("sqlConnection"))
           // UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=TestDb;Integrated Security=True")
       });
    }
}
