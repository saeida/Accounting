
using AutoMapper;

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface.User;
using Domain.Model.User;
using Infrastructure.Persistence.Entities.CrudTest;
using Domain.Model.Customer;

namespace Infrastructure.Persistence.Repositories.User
{
    public class TokenCommandRepository : ITokenCommandRepository
    {
        protected readonly CrudtestContext _context;
        private readonly IMapper _mapper;

        public TokenCommandRepository(CrudtestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


      

        public async Task<Int64> Add(RefreshTokenModel model)
        {
            var entity = _mapper.Map<RefreshToken>(model);
            await _context.Set<RefreshToken>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
