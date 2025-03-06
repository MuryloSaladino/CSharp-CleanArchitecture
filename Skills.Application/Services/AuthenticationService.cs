using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Skills.Application.Common.Exceptions;
using Skills.Application.Config;
using Skills.Domain.Common;
using Skills.Domain.Contracts;
using Skills.Domain.Entities;

namespace Skills.Application.Services;

public class AuthenticationService : IAuthenticator
{
    public string SecretKey { get; private set; } = DotEnv.Get("SECRET_KEY");
    public int ExpireHours { get; private set; } = int.Parse(DotEnv.Get("EXPIRE_HOURS"));

    public string GenerateUserToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(SecretKey);
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity([ 
                new Claim("userId", user.Id.ToString()),
                new Claim("username", user.Username), 
                new Claim("isAdmin", user.IsAdmin.ToString())
            ]),
            
            Expires = DateTime.UtcNow.AddHours(ExpireHours),
            
            SigningCredentials = new(
                new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature
            ),
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public UserSession ExtractToken(string token)
    {
        var key = Encoding.ASCII.GetBytes(SecretKey);
        var tokenHandler = new JwtSecurityTokenHandler();

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };

        try
        {
            var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

            var userId = principal.FindFirst("userId")?.Value;
            var username = principal.FindFirst("username")?.Value;
            var isAdmin = bool.Parse( principal.FindFirst("isAdmin")?.Value ?? "False" );

            if(userId == null || username == null)
                throw new SecurityTokenException("Invalid token: missing claims.");

            return new UserSession(username, userId, isAdmin);
        }
        catch
        {
            throw new AppException("Invalid token", 401);
        }
    }
}

