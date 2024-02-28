using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using RentApp.Models.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RentApp.BussinesLayer.Helpers
{
    public class AuthenticationTokens : IAuthenticationTokens
    {
        IConfiguration _configuration;
        public AuthenticationTokens(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TokenModel GenerateToken(string userName, string role)
        {
            var appKey = _configuration["Jwt:JwtKey"];
            var appExpiredMinutes = _configuration["Jwt:JwtExpireMinutes"];
            var appIssuer = _configuration["Jwt:JwtIssuer"];
            var appAudience = _configuration["Jwt:JwtAudience"];
            var expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(Convert.ToString(appExpiredMinutes)));
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,userName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,userName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Convert.ToString(appKey)));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: appIssuer, audience: appAudience, claims, expires: expires, signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return new TokenModel
            {
                Token = jwt,
                DateExpires = expires,
            };
        }

        public async Task<bool> TokenValidate(string token)
        {
            var appKey = _configuration["Jwt:JwtKey"];
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(appKey);
                var tokenParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
                var tokenValidate = await tokenHandler.ValidateTokenAsync(token, tokenParameters);
                return tokenValidate.IsValid;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
