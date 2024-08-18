using System;
using test_dotnet_app.Services.DepartmentFeature;
using test_dotnet_app.Services.EmployeeFeature;

namespace test_dotnet_app.Extensions;

public static class ConfigureServiceWrapper
{
    public static void ConfigureService(this IServiceCollection services)
    {
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
    }
}
