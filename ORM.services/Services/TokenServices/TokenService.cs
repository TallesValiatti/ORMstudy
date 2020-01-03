using ORM.entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ORM.entity.Permissions;

namespace ORM.services.Services.TokenService
{
    public class TokenService : ITokenServices
    {
        public string genereteToken(UserModel user)
        {
            // add all permissions using claims
            var claims = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.name.ToString()),
                new Claim(ClaimTypes.Role, user.name.ToString())
            });

            foreach (var permission in Enum.GetValues(typeof(Permissions.EnumPermissions)))
                claims.AddClaim(new Claim(ClaimTypes.Role, ((int)permission).ToString()));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
