
using Domain.Interface.Customer;
using Domain.Model.Customer;
using Infrastructure.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories.Customer
{
    public class CustomerQueryRepository : QueryRepository<CustomerModel>, ICustomerQueryRepository
    {
        public CustomerQueryRepository(CRUDTESTContext context) : base(context)
        {

        }

        //Implement Methods That Not Exist In Generic Class

        //public async Task<List<CustomerModel>> GetAllAsync()
        //{
        //    ///This Operation can Do by AutoMapper

        //    var tempResult = _dbContext.Customers.ToList();
        //    List<CustomerModel> result = new List<CustomerModel>();

        //    tempResult.ForEach(x =>
        //    {
        //        CustomerModel cm = new CustomerModel();
        //        cm.Id = x.Id;
        //        cm.Firstname = x.Firstname;
        //        cm.Lastname = x.Lastname;
        //        cm.PhoneNumber = x.PhoneNumber;
        //        cm.DateOfBirth = x.DateOfBirth;
        //        cm.BankAccountNumber = x.BankAccountNumber;
        //        cm.Email = x.Email;
        //        result.Add(cm);
        //    });


        //    return result;
        //}

        //public async Task<CustomerModel> GetByIdAsync(long id)
        //{
        //    var tempResult = _dbContext.Customers.Where(x => x.Id == id).SingleOrDefault();


        //    CustomerModel result = new CustomerModel();
        //    result.Id = tempResult.Id;
        //    result.Firstname = tempResult.Firstname;
        //    result.Lastname = tempResult.Lastname;
        //    result.PhoneNumber = tempResult.PhoneNumber;
        //    result.DateOfBirth = tempResult.DateOfBirth;
        //    result.BankAccountNumber = tempResult.BankAccountNumber;
        //    result.Email = tempResult.Email;

        //    return result;

        //}


    }
}
