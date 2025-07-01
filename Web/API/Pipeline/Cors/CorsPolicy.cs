namespace Web.API.Pipeline.Cors;

public static class CorsPolicyExtensions
{
    public static void ConfigureCorsPolicy(this IServiceCollection services)
    {
        string corsOriginsConfig = Environment.GetEnvironmentVariable("CORS_ORIGINS") ?? "";
        string[] origins = corsOriginsConfig.Split(",");

        services.AddCors(opt =>
            opt.AddDefaultPolicy(builder => builder
                .WithOrigins(origins)
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader()
            )
        );
    }
}