
using Domain.Model.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customer.Queries.GetAllCustomer
{
    public record GetAllCustomerQuery : IRequest<List<CustomerModel>>
    {

    }
}
