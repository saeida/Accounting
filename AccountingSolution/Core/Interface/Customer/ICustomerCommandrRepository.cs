
using Domain.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Customer
{
    public interface ICustomerCommandRepository : ICommandRepository<CustomerModel>
    {

    }
}
