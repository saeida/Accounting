
using Domain.Interface.Customer;
using Domain.Model.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customer.Queries.GetAllCustomer
{
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery, List<CustomerModel>>
    {
        private readonly ICustomerQueryRepository _customerQueryRepository;

        public GetAllCustomerHandler(ICustomerQueryRepository customerQueryRepository)
        {
            _customerQueryRepository = customerQueryRepository;
        }
        public async Task<List<CustomerModel>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            return (List<CustomerModel>)await _customerQueryRepository.GetAllAsync();
        }
    }
}
