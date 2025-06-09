
using AutoMapper;
using Domain.Interface.Customer;
using Core.Model.Customer; // Changed to Core.Model.Customer
using Infrastructure.Persistence.Entities;
using Infrastructure.Persistence.Entities.CrudTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories.Customer
{
    public class CustomerQueryRepository :  ICustomerQueryRepository
    {

        protected readonly CrudtestContext _context;
        private readonly IMapper _mapper;

        public CustomerQueryRepository(CrudtestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<List<CustomerModel>> GetAllAsync()
        {
            

            var tempResult = _context.Customers.ToList();
        
            var result = _mapper.Map<List<CustomerModel>>(tempResult);


            //tempResult.ForEach(x =>
            //{
            //    CustomerModel cm = new CustomerModel();
            //    cm.Id = x.Id;
            //    cm.Firstname = x.Firstname;
            //    cm.Lastname = x.Lastname;
            //    cm.PhoneNumber = x.PhoneNumber;
            //    cm.DateOfBirth = x.DateOfBirth;
            //    cm.BankAccountNumber = x.BankAccountNumber;
            //    cm.Email = x.Email;
            //    result.Add(cm);
            //});


            return result;
        }

        public async Task<CustomerModel> GetByIdAsync(long id)
        {
            var tempResult = _context.Customers.Where(x => x.Id == id).SingleOrDefault();

            if (tempResult == null)
            {
                return null; // Or throw not found exception
            }

            CustomerModel result = new CustomerModel(); // This will now be Core.Model.Customer.CustomerModel
            result.Id = tempResult.Id;
            result.Firstname = tempResult.Firstname;
            result.Lastname = tempResult.Lastname;
            result.PhoneNumber = tempResult.PhoneNumber;
            result.DateOfBirth = tempResult.DateOfBirth;
            result.BankAccountNumber = tempResult.BankAccountNumber;
            result.Email = tempResult.Email;

            return result;

        }

       
    }
}
