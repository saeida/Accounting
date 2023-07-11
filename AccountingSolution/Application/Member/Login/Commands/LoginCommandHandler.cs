
using Application.Resources;
using Application.User.Queries;
using Domain.Interface;
using Domain.Interface.User;
using Domain.Model.User;
using MediatR;
using Microsoft.AspNet.Identity;

using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

namespace Application.Member.Login.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResultModel>
    {


        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IJwtProvider _iJwtProvider;

     public LoginCommandHandler(IUserCommandRepository userCommandRepository, IJwtProvider iJwtProvider)
        {
            _userCommandRepository = userCommandRepository;
            _iJwtProvider = iJwtProvider;
        }


        public async Task<LoginResultModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            UserModel um = new UserModel();
            um.Username = request.UserName;
            um.Password = request.Password;
            string token;
            var validator = new LoginCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

            var user = await _userCommandRepository.GetUserByUsernameandPassword(um);

            var cultureInfo = CultureInfo.GetCultureInfo("en-US");  // یا "fa-IR" برای زبان فارسی
            var resourceManager = new ResourceManager("Application.Resources.Message", Assembly.GetExecutingAssembly());
            var message = resourceManager.GetString(MessageKeys.InvalidUserorPassword, CultureInfo.CurrentCulture);

        
            if (user == null)
            {
                throw new Exception(message);
            }
            else
            {

                 token = await _iJwtProvider.GenerateAsync(user);
            }



            var result = new LoginResultModel (  token,  "" );

            return result;
           
        }
    }
}
