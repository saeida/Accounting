using Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Jwt
{
    public interface IJwtProvider
    {
        Task<string> GenerateAsync(UserModel User);
        Task<string> GenerateRefreshToken(string jwtToken);
        Task<TokenResultModel> VerifyToken(TokenResultModel tokenRequest, RefreshTokenModel storedRefreshToken);
    }
}
