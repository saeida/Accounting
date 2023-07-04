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

        private readonly IMapper _mapper;
        public UserCommandRepository(  IMapper mapper)
        {
        
            _mapper = mapper;
        }


        public async Task<UserModel> GetUserByUsernameandPassword(string Username,string Password)
        {
           
          
            return null;

        }









    }
}
