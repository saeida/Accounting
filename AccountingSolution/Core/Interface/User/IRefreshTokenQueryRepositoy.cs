using Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.User
{
    public interface IRefreshTokenQueryRepositoy
    {
        Task<RefreshTokenModel> FindRefreshToken(string refreshToken);
        Task<RefreshTokenModel> Update(RefreshTokenModel refreshToken);
        public Task<Int64> Logout(string JwtId);
    }
}
