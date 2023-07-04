using Domain.Model.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Member.Login.Commands
{
    public class LoginCommand : IRequest<LoginResultModel>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
