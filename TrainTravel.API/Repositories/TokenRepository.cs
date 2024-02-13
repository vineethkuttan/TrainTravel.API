using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrainTravel.API.Model.Domain;

namespace TrainTravel.API.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration configuration;

        public TokenRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string CreateJWTAccessToken(TrainTravelUser user, List<string> roles)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var accessTokenExpiration = DateTime.Now.AddMinutes(15); 

            var accessToken = GenerateToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"], key, claims, accessTokenExpiration);

            return accessToken;
        }

        public (string accessToken, string refreshToken) CreateJWTToken(TrainTravelUser user, List<string> roles)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var refreshkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:RefreshKey"]));

            var accessTokenExpiration = DateTime.Now.AddMinutes(15);
            var refreshTokenExpiration = DateTime.Now.AddMinutes(30); // You can adjust the expiration time for refresh tokens as needed.

            var accessToken = GenerateToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"], key, claims, accessTokenExpiration);
            var refreshToken = GenerateToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"], refreshkey, null, refreshTokenExpiration);
            //var refreshToken = accessToken;

            return (accessToken, refreshToken);
        }
        private string GenerateToken(string issuer, string audience, SymmetricSecurityKey key, List<Claim> claims, DateTime expires)
        {
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expires,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
