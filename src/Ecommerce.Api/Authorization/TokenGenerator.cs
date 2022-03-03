using Ecommerce.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.Api
{
    public static partial class Policies
    {
        public class TokenGenerator : ITokenGenerator
        {
            public const string ApiKeyConfigurationName = "SecretKey";
            public const int ExpirationDays = 1;

            private readonly IConfiguration configuration;

            public TokenGenerator(IConfiguration configuration)
            {
                this.configuration = configuration;
            }

            public string GenerateToken(User user)
            {
                string secret = configuration.GetValue<string>(ApiKeyConfigurationName);
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(secret);

                var claims = new List<Claim>()
                {
                    new Claim(CustomClaims.UserId, user.Id.ToString()),
                    new Claim(CustomClaims.Name, user.ToString()),
                };
                claims.AddRange(user.GetCompanyRoles().Select(x => new Claim(CustomClaims.RoleInCompany, x.ToClaim())));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(ExpirationDays),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                return tokenString;
            }
        }
    }
}