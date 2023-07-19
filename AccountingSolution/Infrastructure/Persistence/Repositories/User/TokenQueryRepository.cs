using AutoMapper;
using Domain.Interface.User;
using Domain.Model.User;
using Infrastructure.Persistence.Entities.Samina;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories.User
{
    public class TokenQueryRepository : ITokenQueryRepository
    {

        protected readonly SaminaDbContext _context;
        private readonly IMapper _mapper;

        public TokenQueryRepository(SaminaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RefreshTokenModel> FindRefreshToken(string refreshToken)
        {
            var tempResult =await _context.RefreshTokens.Where(x => x.Token == refreshToken).SingleOrDefaultAsync();
            RefreshTokenModel rtm = null;

            if (tempResult != null)
            {
                 rtm = _mapper.Map<RefreshTokenModel>(tempResult);
            }
            return rtm;

        }

        public Task<long> Logout(string JwtId)
        {
            throw new NotImplementedException();
        }

        public async Task<long> Update(RefreshTokenModel refreshToken)
        {
            _context.RefreshTokens.Where(x => x.JwtId == refreshToken.JwtId).SingleOrDefault().IsRevoked = true;
            return await _context.SaveChangesAsync();
        }

       
    }
}
