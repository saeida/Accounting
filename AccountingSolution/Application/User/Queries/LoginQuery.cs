using Domain.Model.Customer;
using Domain.Model.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Queries
{
    public class LoginQuery : IRequest<UserModel>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
