
using AutoMapper;
using Domain.Interface.Customer;
using Domain.Model.Customer;
using Infrastructure.Persistence.Entities;
using Infrastructure.Persistence.Entities.CrudTest;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories.Customer
{
    public class CustomerCommandRepository : ICustomerCommandRepository
    {

        protected readonly CrudtestContext _context;
        private readonly IMapper _mapper;

        //public CustomerCommandRepository(CRUDTESTContext context) : base(context)
        public CustomerCommandRepository(CrudtestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }


        public async Task<Int64> AddAsync(CustomerModel model)
        {
            var entity = _mapper.Map<Infrastructure.Persistence.Entities.CrudTest.Customer>(model);
            await _context.Set<Infrastructure.Persistence.Entities.CrudTest.Customer >().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }


        public async Task UpdateAsync(CustomerModel model)
        {
            var entity = _mapper.Map<Infrastructure.Persistence.Entities.CrudTest.Customer >(model);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(CustomerModel model)
        {
            var entity = _mapper.Map<Infrastructure.Persistence.Entities.CrudTest.Customer >(model);
            _context.ChangeTracker.Clear();
            _context.Set<Infrastructure.Persistence.Entities.CrudTest.Customer >().Remove(entity);
            await _context.SaveChangesAsync();
        }

      
    }
}
