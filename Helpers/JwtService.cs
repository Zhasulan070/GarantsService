using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace GarantsService.Helpers
{
    public class JwtService
    {
        private string key = "This is very strong key";

        public string Generate(int id)
        {
            var sym = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(sym, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);

            var payload = new JwtPayload(id.ToString(), null, null, null, DateTime.Today.AddHours(12));
            var securityToken = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public JwtSecurityToken Verify(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var bytes = Encoding.ASCII.GetBytes(key);
            tokenHandler.ValidateToken(jwt, 
                new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(bytes),
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out SecurityToken validatedToken);

            return (JwtSecurityToken) validatedToken;
        }

    }
}