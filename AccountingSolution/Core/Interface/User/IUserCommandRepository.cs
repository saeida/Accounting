using Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.User
{
    public interface IUserCommandRepository
    {
        public Task<UserModel> GetUserByUsernameandPassword(string Username, string Password);
    }
}
