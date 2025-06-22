using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Skills.Domain.Exceptions;

namespace Skills.API.Pipeline.Handlers;

public static class ErrorHandlerExtensions
{
    public static void UseErrorHandler(this IApplicationBuilder app) =>
        app.UseExceptionHandler(error =>
        {
            error.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if(contextFeature is null) return;

                var statusCode = contextFeature.Error switch
                {
                    AppException appError => appError.StatusCode,
                    _ => ExceptionCode.InternalServerError
                };
                var message = contextFeature.Error switch
                {
                    AppException appError => appError.Message,
                    _ => "Internal Server Error"
                };

                context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)statusCode;

                var errorResponse = new { statusCode, message };

                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
            });
        });
}