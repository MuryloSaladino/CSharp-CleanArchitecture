using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Domain.Common;
using Domain.Enums;

namespace Web.API.Pipeline.Handlers;

public static class ErrorHandlerExtensions
{
    public static void UseErrorHandler(this IApplicationBuilder app) =>
        app.UseExceptionHandler(error =>
        {
            error.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if(contextFeature is null) return;

                context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)(contextFeature.Error switch
                {
                    BaseException appError => appError.Code,
                    _ => ExceptionCode.InternalServerError,
                });

                await context.Response.WriteAsync(JsonSerializer.Serialize(contextFeature.Error));
            });
        });
}