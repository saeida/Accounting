using Domain.Interface;
using Domain.Model.User;
using Infrastructure.Authentication.Permission;
using Infrastructure.Persistence.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication.JWT
{
    internal sealed class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _options;
        private readonly IPermissionService _permissionService;
        public JwtProvider(IOptions<JwtOptions> options, IPermissionService permissionService )
        {
            _options = options.Value;
            _permissionService = permissionService;
        }
        public async Task<string> GenerateAsync(UserModel user)
        {
          //  var claims = new Claim [] { };
            var claims = new List<Claim>
             {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),            
                new Claim(ClaimTypes.Email, user.Email),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

            };

            var permissions = await _permissionService.GetPermissionsAsync(user.Id);

            foreach (var permission in permissions)
            {
                claims.Add(new Claim(CustomClaims.Permissions, permission));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = creds,
                Audience = _options.Audience,
                Issuer = _options.Issuer
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
          


        }
    }
}
