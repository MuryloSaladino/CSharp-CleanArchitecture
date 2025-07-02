namespace Application.Configuration;

public enum AppEnvironment
{
    Production,
    Development,
    Test,
}

public interface IAppConfiguration
{
    AppEnvironment AppEnvironment { get; }
    string GetConfig(string config);
    string GetSecret(string secret);
}
