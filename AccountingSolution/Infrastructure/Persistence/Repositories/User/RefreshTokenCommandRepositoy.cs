
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

namespace Infrastructure.Persistence.Repositories.User
{
    public class RefreshTokenCommandRepositoy : IRefreshTokenCommandRepositoy
    {
        protected readonly CrudtestContext _context;
        private readonly IMapper _mapper;

        public RefreshTokenCommandRepositoy(CrudtestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<RefreshTokenModel> Add(RefreshTokenModel refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
