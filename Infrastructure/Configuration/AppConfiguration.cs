using Application.Configuration;
using dotenv.net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Protocols.Configuration;

namespace Infrastructure.Configuration;

public class AppConfiguration : IAppConfiguration
{
    private readonly IConfiguration _config;
    private readonly IHostEnvironment _env;

    public AppConfiguration(IConfiguration configuration, IHostEnvironment environment)
    {
        DotEnv.Load();
        _config = configuration;
        _env = environment;
    }

    public AppEnvironment AppEnvironment => Enum.Parse<AppEnvironment>(_env.EnvironmentName);

    public string GetConfig(string config)
        => _config[$"AppSettings:{config}"]
            ?? throw new InvalidConfigurationException($"Invalid configuration setup for {config}: value not set");

    public string GetSecret(string secret)
        => Environment.GetEnvironmentVariable(secret)
            ?? throw new InvalidConfigurationException($"Invalid configuration setup for {secret}: value not set");
}
