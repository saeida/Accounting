using Application.Customer.Commands.CreateCustomer;
using Domain.Interface.Customer;
using Domain.Interface.User;
using Domain.Model.User;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, UserModel>
    {

        private readonly IUserQueryRepository _userQueryRepository;
        public LoginQueryHandler(IUserQueryRepository userQueryRepository)
        {
            _userQueryRepository = userQueryRepository;
        }
        public async Task<UserModel> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            UserModel um = new UserModel();
            um.UserName = request.UserName;
            um.Password = request.Password;

            var validator = new LoginQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

            var user = await _userQueryRepository.GetUserByUsernameAndPassword(um);

            return user;

        }
    }
}
