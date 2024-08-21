using System;

namespace test_dotnet_app.Extensions;

public static class ConfigureMiddlewareWrapper
{
    public static void ConfigureMiddleware(this WebApplication app, ILogger logger)
    {
        app.MapGet("/", (IApplicationBuilder _app)=>{
            _app.Use(async (context, next)=>{
                logger.LogInformation("Request received at: {time}", DateTime.Now);
                await next();
            });
        });
    }
}
