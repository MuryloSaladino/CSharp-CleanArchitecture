using System.Security.Cryptography;
using Skills.Domain.Common.Exceptions;

namespace Skills.Domain.Common.Generators;

public static class PasswordGenerator
{
    private const string Uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string Lowercase = "abcdefghijklmnopqrstuvwxyz";
    private const string Digits = "0123456789";
    private const string Symbols = "!@#$%^&*()-_=+[]{}|;:,.<>?";

    private static readonly char[] AllChars = (Uppercase + Lowercase + Digits + Symbols).ToCharArray();

    public static string GenerateStrongPassword(int length = 12)
    {
        if (length < 8)
            throw new AppException(ExceptionCode.BadRequest, ExceptionMessages.BadRequest.PasswordLength);

        var password = new char[length];
        var rng = RandomNumberGenerator.Create();

        password[0] = GetRandomChar(Uppercase, rng);
        password[1] = GetRandomChar(Lowercase, rng);
        password[2] = GetRandomChar(Digits, rng);
        password[3] = GetRandomChar(Symbols, rng);

        for (int i = 4; i < length; i++)
            password[i] = GetRandomChar(AllChars, rng);

        Shuffle(password, rng);

        return new string(password);
    }

    private static char GetRandomChar(string chars, RandomNumberGenerator rng)
    {
        return chars[GetRandomInt(rng, chars.Length)];
    }

    private static char GetRandomChar(char[] chars, RandomNumberGenerator rng)
    {
        return chars[GetRandomInt(rng, chars.Length)];
    }

    private static int GetRandomInt(RandomNumberGenerator rng, int max)
    {
        var bytes = new byte[4];
        rng.GetBytes(bytes);
        return (int)(BitConverter.ToUInt32(bytes, 0) % (uint)max);
    }

    private static void Shuffle(char[] array, RandomNumberGenerator rng)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = GetRandomInt(rng, i + 1);
            (array[i], array[j]) = (array[j], array[i]);
        }
    }
}