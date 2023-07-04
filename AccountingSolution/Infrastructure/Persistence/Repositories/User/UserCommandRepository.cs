using AutoMapper;
using Azure.Core;
using Domain.Interface.User;
using Domain.Model.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Persistence.Repositories
{
    public class UserCommandRepository: IUserCommandRepository
    {
        private readonly UserManager<Infrastructure.Persistence.Entities.ApplicationUser> _userManager;
        private readonly SignInManager<Infrastructure.Persistence.Entities.ApplicationUser> _signInManager;
        private readonly IMapper _mapper;
        public UserCommandRepository(UserManager<Infrastructure.Persistence.Entities.ApplicationUser> userManager, SignInManager<Infrastructure.Persistence.Entities.ApplicationUser> signInManager, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }


        public async Task<UserModel> GetUserByUsernameandPassword(string Username,string Password)
        {
           
            var user = await _userManager.FindByNameAsync(Username);
            if (user != null)
            {
                var checkResult = await _signInManager.CheckPasswordSignInAsync(user, Password, lockoutOnFailure: false);
                if (!checkResult.Succeeded)
                {
                    return null;
                }              
            }

            var result = _mapper.Map<UserModel>(user);
            return result;

        }









    }
}
