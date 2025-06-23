using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Protocols.Configuration;
using Skills.Domain.Identity;
using Skills.Domain.Exceptions;

namespace Skills.Infrastructure.Identity.Services;

public class TokenAuthenticator : ITokenAuthenticator
{
    private string SecretKey { get; } = Environment.GetEnvironmentVariable("JWT_SECRET_KEY")
        ?? throw new InvalidConfigurationException("The environment needs \"SECRET_KEY\" variable");

    public string GenerateToken(TokenPayload payload)
    {
        var key = Encoding.ASCII.GetBytes(SecretKey);
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim(ClaimTypes.NameIdentifier, payload.UserId.ToString()),
                new Claim(ClaimTypes.Role, payload.IsAdmin.ToString()),
                new Claim(ClaimTypes.Name, payload.Username),
            ]),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            ),
            IssuedAt = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddMinutes(15)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    
    public TokenPayload Extract(string token)
    {
        var key = Encoding.ASCII.GetBytes(SecretKey);
        var tokenHandler = new JwtSecurityTokenHandler();

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero,
        };

        try
        {
            var principal = tokenHandler.ValidateToken(token, validationParameters, out _);

            var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new SecurityTokenException($"Missing { ClaimTypes.NameIdentifier } claim");
            var isAdmin = principal.FindFirst(ClaimTypes.Role)?.Value
                ?? throw new SecurityTokenException($"Missing { ClaimTypes.Role } claim");
            var username = principal.FindFirst(ClaimTypes.Name)?.Value
                ?? throw new SecurityTokenException($"Missing { ClaimTypes.Name } claim");

            return new()
            {
                UserId = Guid.Parse(userId),
                IsAdmin = bool.Parse(isAdmin),
                Username = username,
            };
        }
        catch (Exception ex)
        {
            throw new AppException(
                ExceptionCode.Unauthorized,
                ExceptionMessages.Unauthorized.Default,
                ex.Message
            );
        }
    }
}

