using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Skills.Application.Configuration;
using Skills.Domain.Contracts;

namespace Skills.Application.Services;

public class AuthenticationService(AppConfiguration appConfiguration) : IAuthenticationService
{
    private readonly AppConfiguration appConfiguration = appConfiguration;

    public string GenerateUserToken(string userId)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(appConfiguration.SecretKey);
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity([ new Claim("id", userId) ]),
            
            Expires = DateTime.UtcNow.AddHours(appConfiguration.ExpireHours),
            
            SigningCredentials = new(
                new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature
            ),
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}