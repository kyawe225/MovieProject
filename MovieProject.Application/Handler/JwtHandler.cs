using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovieProject.Core.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieProject.Handler
{
    public interface IJwtHandler
    {
        public TokenResult GenerateToken(User user);
        public TokenResult GenerateRefreshToken(User user);
    }
    public class JwtHandler : IJwtHandler
    {
        private readonly string AuthSigningKey;
        private readonly string RefreshSigningKey;
        private readonly string Issuer;
        private readonly string Audience;
        private readonly int AuthDuration; // this should be minutes
        private readonly long RefreshDuration; // this should be minutes
        public JwtHandler(IConfiguration configuration)
        {
            Issuer = configuration.GetValue<string>("Jwt:Issuer", "");
            Audience = configuration.GetValue<string>("Jwt:Audience", "");
            AuthSigningKey = configuration.GetValue<string>("TokenSigningKeys:Authentication", "");
            RefreshSigningKey = configuration.GetValue<string>("TokenSigningKeys:Refresh", "");
            AuthDuration = configuration.GetValue<int>("TokenExpireDuration:Authentication", 0);
            RefreshDuration = configuration.GetValue<long>("TokenExpireDuration:Refresh", 0);
        }

        public TokenResult GenerateToken(User user)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier , user.Id),
                new Claim(ClaimTypes.GivenName , user.Name),
                new Claim(ClaimTypes.Name, "access"),
                new Claim(ClaimTypes.Email , user.Email),
                new Claim(JwtRegisteredClaimNames.Name, user.Name),
                new Claim(ClaimTypes.Role , user.RoleId),
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString())
            };
            DateTime ExpireTime = DateTime.UtcNow.AddMinutes(AuthDuration);

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthSigningKey));
            SigningCredentials credential = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(Issuer,Audience,claims,DateTime.UtcNow,ExpireTime,credential);

            var tokenHandler = new JwtSecurityTokenHandler();

            return new TokenResult(tokenHandler.WriteToken(token),ExpireTime);
        }

        public TokenResult GenerateRefreshToken(User user)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier , user.Id),
                new Claim(ClaimTypes.GivenName , user.Name),
                new Claim(JwtRegisteredClaimNames.Name, user.Name),
                new Claim(ClaimTypes.Email , user.Email),
                new Claim(ClaimTypes.Name, "refresh"),
                new Claim(ClaimTypes.Role , user.RoleId),
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString())
            };
            DateTime ExpireTime = DateTime.UtcNow.AddMinutes(RefreshDuration);

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(RefreshSigningKey));
            SigningCredentials credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(Issuer, Audience, claims, DateTime.UtcNow, ExpireTime , credential);

            var tokenHandler = new JwtSecurityTokenHandler();

            return new TokenResult(tokenHandler.WriteToken(token), ExpireTime);
        }
    }

    public struct TokenResult
    {
        public string Token { set; get; }
        public DateTime ExpireTime { set; get; }
        public TokenResult(string Token, DateTime ExpireTime)
        {
            this.Token = Token;
            this.ExpireTime = ExpireTime;
        }
    }
}
