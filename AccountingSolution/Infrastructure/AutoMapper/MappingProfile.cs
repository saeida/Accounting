using AutoMapper;
using Domain.Model.Customer;
using Infrastructure.Persistence.Entities;
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
            CreateMap<Customer, CustomerModel>();
            CreateMap<CustomerModel, Customer>();
            CreateMap<List<Customer>, List<CustomerModel>>();
            CreateMap<List<CustomerModel>, List<Customer>>();
        }
    }
}
