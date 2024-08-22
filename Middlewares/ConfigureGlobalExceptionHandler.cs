using System;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using test_dotnet_app.DTO;
using test_dotnet_app.Utils;

namespace test_dotnet_app.Middlewares;

public static class ConfigureGlobalExceptionHandlerWrapper
{
    public static void ConfigureGlobalExceptionHandler(this WebApplication app, ILogger logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/json";

                var exception = context.Features.Get<IExceptionHandlerFeature>();

                if (exception != null)
                {
                    context.Response.StatusCode = exception.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        CustomErrorException customError => customError.ErrorCode,
                        _ => StatusCodes.Status500InternalServerError,
                    };
                    logger.LogError($"An error occurred: {exception.Error}");
                    var message = exception.Error switch
                    {
                        NotFoundException => "Not Found",
                        CustomErrorException customError => customError.ErrorMessage,
                        _ => exception.Error.Message ?? "An unexpected error occurred. Please try again later."
                    };
                    await context.Response.WriteAsync(new ErroDetails(
                        context.Response.StatusCode,
                        message).ToString());
                }
            });
        });
    }
}




// StatusCode: context.Response.StatusCode,
//                         Message: "An unexpected error occurred. Please try again later."

// StatusCode= context.Response.StatusCode,
//                         Message = exception.Error.Message?? "An unexpected error occurred. Please try again later."