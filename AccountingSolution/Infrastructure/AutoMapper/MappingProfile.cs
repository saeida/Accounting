using AutoMapper;
using Domain.Model.Customer;
using Domain.Model.User;
using Infrastructure.Persistence.Entities;
using Infrastructure.Persistence.Entities.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
         
        
        
            CreateMap<RefreshToken, RefreshTokenModel>();
            CreateMap<RefreshTokenModel, RefreshToken>();

        }
    }
}
