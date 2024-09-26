using System.Text;

namespace Skills.Application.Configuration;

public class AppConfiguration
{
    public string SecretKey { get; } = GenerateKey(50);
    public int ExpireHours { get; } = 3;


    private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    private static string GenerateKey(int length)
    {
        var key = new StringBuilder(length);
        
        for (int i = 0; i < length; i++)
            key.Append(chars[Random.Shared.Next(chars.Length)]);
        return key.ToString();
    }
}