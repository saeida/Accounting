
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
    public class CustomerCommandRepository : CommandRepository<CustomerModel>, ICustomerCommandRepository
    {
        public CustomerCommandRepository(CRUDTESTContext context) : base(context)
        {

        }
    }
}
