using AutoMapper;
using Domain.Interface.User;
using Domain.Model.Customer;
using Domain.Model.User;
using Infrastructure.Persistence.Entities;
using Infrastructure.Persistence.Entities.Samina;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Infrastructure.Persistence.Repositories.User
{
    internal class UserQueryRepository : IUserQueryRepository
    {
        protected readonly SaminaDbContext _context;
        private readonly IMapper _mapper;

        public UserQueryRepository(SaminaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserModel> GetUserByUsernameAndPassword(UserModel user)
        {

            var tempResult = await _context.Users.Where(x => x.Username == user.Username && x.Password == user.Password).SingleOrDefaultAsync();

            if(tempResult == null) { return null; }

            var result = _mapper.Map<UserModel>(tempResult);

            return result;

        }
    }
}
