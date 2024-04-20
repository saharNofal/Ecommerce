
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace SimpleEcommerce.Api
{
   

    public class JwtTokenService
    {
        private readonly string _issuer;
        private readonly string _audience;
        private readonly string _key;

        public JwtTokenService(string issuer, string audience, string key)
        {
            _issuer = issuer;
            _audience = audience;
            _key = key;
        }

        public string GenerateToken(string userId, string email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Email, email)
            // Add more claims as needed
        };

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Token expiration time
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }

}
