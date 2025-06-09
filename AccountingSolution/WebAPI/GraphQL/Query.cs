using MediatR;
using Core.Model.Customer; // Corrected namespace
using Application.Customer.Queries.GetAllCustomer;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.AspNetCore.Authorization; // For [Authorize]
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.GraphQL
{
    public class Query
    {
        private readonly IMediator _mediator;

        public Query(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IEnumerable<CustomerModel>> GetCustomers()
        {
            var query = new GetAllCustomerQuery();
            var result = await _mediator.Send(query);
            return result;
        }
    }
}
