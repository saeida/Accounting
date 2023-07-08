using AutoMapper;
using Azure.Core;
using Domain.Interface.User;
using Domain.Model.User;
using Infrastructure.Persistence.Entities;
using Infrastructure.Persistence.Entities.CrudTest;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        protected readonly CrudtestContext _context;
        private readonly IMapper _mapper;
        public UserCommandRepository(CrudtestContext context,  IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
             

        public async Task<UserModel> GetUserByUsernameandPassword(UserModel user)
        {
            var tempResult = await _context.Users.Where(x => x.Username == user.Username && x.Password == user.Password).SingleOrDefaultAsync();
            if (tempResult == null) { return null; }
            var result = _mapper.Map<UserModel>(tempResult);
            return result;
        }
    }
}
