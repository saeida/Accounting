﻿
using Domain.Interface.Customer;
using Domain.Model.Customer;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Int64>
    {
        private readonly ICustomerCommandRepository _customerRepository;
        public CreateCustomerCommandHandler(ICustomerCommandRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Int64> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {

            //var cultureInfo = CultureInfo.GetCultureInfo("en-US");  // یا "fa-IR" برای زبان فارسی
          

            //var resourceManager = new ResourceManager("Application.Resources.Message", Assembly.GetExecutingAssembly());
            //var message = resourceManager.GetString("InvalidUserorPassword", CultureInfo.CurrentCulture);


            CustomerModel cm = new CustomerModel();
            cm.Firstname = command.Firstname;
            cm.Firstname = command.Firstname;
            cm.Lastname = command.Lastname;
            cm.PhoneNumber = command.PhoneNumber;
            cm.DateOfBirth = command.DateOfBirth;
            cm.BankAccountNumber = command.BankAccountNumber;
            cm.Email = command.Email;


            var validator = new CreateCustomerCommandValidator();
            var validationResult = await validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }


            //var validator = new CreateCustomerValidation(_bookRepository);
            //await validator.ValidateAndThrowAsync(command);


            var newCustomerId = await _customerRepository.AddAsync(cm);
            return newCustomerId;
        }

     
    }
}