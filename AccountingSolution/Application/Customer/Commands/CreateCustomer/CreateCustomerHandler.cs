
using Domain.Interface.Customer;
using Domain.Model.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customer.Commands.CreateCustomer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Int64>
    {
        private readonly ICustomerCommandRepository _customerRepository;
        public CreateCustomerHandler(ICustomerCommandRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Int64> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            CustomerModel cm = new CustomerModel();
            cm.Firstname = request.Firstname;
            cm.Firstname = request.Firstname;
            cm.Lastname = request.Lastname;
            cm.PhoneNumber = request.PhoneNumber;
            cm.DateOfBirth = request.DateOfBirth;
            cm.BankAccountNumber = request.BankAccountNumber;
            cm.Email = request.Email;

            var newCustomer = await _customerRepository.AddAsync(cm);
            return newCustomer.Id;
        }

     
    }
}
