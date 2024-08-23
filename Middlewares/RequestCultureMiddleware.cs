using System;
using System.Globalization;

namespace test_dotnet_app.Middlewares;

public class RequestCultureMiddleware : IMiddleware
{
    private readonly ILogger _logger;

    public RequestCultureMiddleware(ILogger<RequestCultureMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        _logger.Log(LogLevel.Debug, "RequestCultureMiddleware invocated with context");
        var cultureQuery=context.Request.Query["culture"];
        if (!string.IsNullOrWhiteSpace(cultureQuery))
        {
            // Set the current culture for the request
            var culture= new CultureInfo(cultureQuery!);
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
        }
        await next(context);
    }
}

public static class RequestCultureMiddlewareExtension
{
    public static IApplicationBuilder UseRequestCultureMiddleware(this IApplicationBuilder application)
    {
        return application.UseMiddleware<RequestCultureMiddleware>();
    }

    public static void RegiserRequestCultureMiddleware(this IServiceCollection services)
    {
        services.AddTransient<RequestCultureMiddleware>();
    }
}