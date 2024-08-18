using System;
using test_dotnet_app.Repositories.DepartmentFeature;
using test_dotnet_app.Repositories.EmployeeFeature;

namespace test_dotnet_app.Extensions;

public static class ConfigureRepositoryWrapper
{
    public static void ConfigureRepository(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        // services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
        // services.AddScoped<ICalendarRepository, CalendarRepository>();
        // services.AddScoped<IDbContext, AppDbContext>();
        // services.AddScoped<IMapper, Mapper>();
        // services.AddScoped<IAuthService, AuthService>();
        // services.AddScoped<IMailService, MailService>();
        // services.AddScoped<IClockService, ClockService>();
        // services.AddScoped<IFileService, FileService>();
        
        // services.AddScoped<IEventLogService, EventLogService>();
        // services.AddScoped<IMigrationService, MigrationService>();
        // services.AddScoped<ISecurityService, SecurityService>();
        // services.AddScoped<ITokenService, TokenService>();
    }
}
