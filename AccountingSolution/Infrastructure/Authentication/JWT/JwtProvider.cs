using Domain.Interface.Jwt;
using Domain.Interface.User;
using Domain.Model.User;
using Infrastructure.Authentication.Permission;
using Infrastructure.Persistence.Entities;

using Infrastructure.Persistence.Repositories.User;
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
        private readonly ITokenCommandRepository _refreshTokenCommandRepositoy;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public JwtProvider(IOptions<JwtOptions> options, IPermissionService permissionService, ITokenCommandRepository refreshTokenCommandRepositoy, TokenValidationParameters tokenValidationParameters)
        {
            _options = options.Value;
            _permissionService = permissionService;
            _refreshTokenCommandRepositoy = refreshTokenCommandRepositoy;
            _tokenValidationParameters = tokenValidationParameters;
        }



        public async Task<string> GenerateAsync(UserModel user)
        {
            //  var claims = new Claim [] { };
            var claims = new List<Claim>
             {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                user.Email != null ? new Claim(ClaimTypes.Email, user.Email) : new Claim(ClaimTypes.Email, ""),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

            };

            var permissions = await _permissionService.GetPermissionsAsync(user.Id);

            foreach (var permission in permissions)
            {
                claims.Add(new Claim(CustomClaims.Permissions, permission));
            }

            return await GenerateToken(claims);
        }

        private async Task<string> GenerateToken(IEnumerable<Claim> claims)
        {

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


        public async Task<string> GenerateRefreshToken(string jwtToken)
        {          

            // ساخت یک instance از JwtSecurityToken با استفاده از JWT token
            JwtSecurityToken token = new JwtSecurityToken(jwtToken);

            // استخراج پارامتر id از Claim با نام "id"
            string id = token.Claims.FirstOrDefault(c => c.Type == "jti")?.Value;
            Int64 userId = long.Parse (token.Claims.FirstOrDefault(x => x.Type == "nameid").Value);


            var refreshToken = new RefreshTokenModel()
            {
                JwtId = id,
                IsUsed = false,
                UserId = userId,
                AddedDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddDays(4),// زمان انقضای رفرش توکن
                IsRevoked = false,
                Token = RandomString(25) + Guid.NewGuid()
            };


            await _refreshTokenCommandRepositoy.Add(refreshToken);
       
            return refreshToken.Token;

        }

        public async Task<TokenResultModel> VerifyToken(TokenResultModel tokenRequest,RefreshTokenModel storedRefreshToken)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            _tokenValidationParameters.ValidateLifetime = false;
            // This validation function will make sure that the token meets the validation parameters
            // and its an actual jwt token not just a random string
            var principal = jwtTokenHandler.ValidateToken(tokenRequest.Token, _tokenValidationParameters, out var validatedToken);
            _tokenValidationParameters.ValidateLifetime = true;

            // Now we need to check if the token has a valid security algorithm
            if (validatedToken is JwtSecurityToken jwtSecurityToken)
            {
                var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

                if (result == false)
                {
                    return null;
                }
            }



            // Will get the time stamp in unix time
            var utcExpiryDate = long.Parse(principal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

            // we convert the expiry date from seconds to the date
            var expDate = UnixTimeStampToDateTime(utcExpiryDate);

            if (expDate > DateTime.UtcNow)
            {
                throw new Exception("توکن شما هنوز معتبر هست ");// throw new Exception(((int)JWTEnum.notExpired).ToString());
                //return new AuthResult() 
                //{
                //    Errors = new List<string>() { JWTEnum.notExpired.ToString() },// "We cannot refresh this since the token has not expired" 
                //    Success = false
                //};
            }

        

            if (storedRefreshToken == null)
            {
                throw new Exception("توکن شما یافت نشد ");
            }

            // Check the date of the saved token if it has expired
            if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
            {
                throw new Exception("رفرش توکن شما منقضی شده است ");
            }

            // check if the refresh token has been used
            if (storedRefreshToken.IsUsed == true)
            {
                throw new Exception("رفرش توکن شما قبلا استفاده شده است ");

            }

            // Check if the token is revoked
            if (storedRefreshToken.IsRevoked == true)
            {
                throw new Exception("توکن شما منقضی شده است");
            }

            // we are getting here the jwt token id
            var jti = principal.Claims.SingleOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            // check the id that the recieved token has against the id saved in the db
            if (storedRefreshToken.JwtId != jti)
            {
                throw new Exception("شناسه توکن معتبر نیست");
            }

        

            var jwtToken=   await GenerateToken(principal.Claims);
            var refreshToken =await GenerateRefreshToken(jwtToken);

            var trm= new TokenResultModel();

            trm.RefreshToken = refreshToken;
            trm.Token = jwtToken; ;
            
            return trm;



        }

        private string RandomString(int length)
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToUniversalTime();
            return dtDateTime;
        }

     
    }
}
