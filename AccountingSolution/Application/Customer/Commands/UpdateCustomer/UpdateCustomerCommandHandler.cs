using Domain.Interface.Customer;
using Domain.Model.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerModel>
    {
        private readonly ICustomerCommandRepository _customerRepository;

        public UpdateCustomerCommandHandler(ICustomerCommandRepository customerRepository, ICustomerCommandRepository customerQueryRepository)
        {
            _customerRepository = customerRepository;
          
        }
        public async Task<CustomerModel> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {


            CustomerModel cm = new CustomerModel();
            cm.Id = request.Id;
            cm.Firstname = request.Firstname;
            cm.Firstname = request.Firstname;
            cm.Lastname = request.Lastname;
            cm.PhoneNumber = request.PhoneNumber;
            cm.DateOfBirth = request.DateOfBirth;
            cm.BankAccountNumber = request.BankAccountNumber;
            cm.Email = request.Email;

            try
            {
                await _customerRepository.UpdateAsync(cm);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var result = cm;

            return result;
        }
    }
}
