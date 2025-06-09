using MediatR;
using Application.Customer.Commands.CreateCustomer;
using Core.Model.Customer;
using HotChocolate;
using HotChocolate.Types; // Added for completeness, though not strictly needed by [Authorize] alone
using HotChocolate.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace WebAPI.GraphQL
{
    public class Mutation
    {
        private readonly IMediator _mediator;

        public Mutation(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = "CustomerPermission.Create")]
        public async Task<CustomerModel> CreateCustomer(CreateCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }
    }
}
