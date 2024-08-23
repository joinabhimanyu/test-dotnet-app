using System;

namespace test_dotnet_app.Middlewares;

public static class ConfigureMiddlewareWrapper
{
    public static void ConfigureMiddleware(this WebApplication app)
    {
        var logger = app.Services.GetRequiredService<ILogger<Program>>();
        app.Use(async (context, next) =>
        {
            logger.LogInformation("Request received at: {time}", DateTime.Now);
            await next();
        });
    }
}
