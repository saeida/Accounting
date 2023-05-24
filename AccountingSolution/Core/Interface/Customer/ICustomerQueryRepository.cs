using Domain.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Customer
{
    public interface ICustomerQueryRepository : IQueryRepository<CustomerModel>
    {

        //Write Method That Not Exists on Generic Interface

        //Task<List<CustomerModel>> GetAllAsync();
        //Task<CustomerModel> GetByIdAsync(Int64 id);

    }
}
