using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidation: AbstractValidator<CreateCustomerCommand>
    {

        //   private readonly IBookRepository _bookRepository;

        //public CreateCustomerValidation(IBookRepository bookRepository)
        //{
        //    _bookRepository = bookRepository;
        //}
        public CreateCustomerCommandValidation()
        {
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.BankAccountNumber).MinimumLength(2);
            //  RuleFor(x => x.BankAccountNumber).InclusiveBetween(200, 600);
            //  RuleFor(x => x.Firstname).NotEmpty().MustAsync(BeUniqueFisrtName).WithMessage("A book with the same title already exists.");
            RuleFor(x => x.Firstname).MustAsync(BeUniqueFisrtName).WithMessage("A book with the same title already exists.");
        }

        private async Task<bool> BeUniqueFisrtName(string title, CancellationToken cancellationToken)
        {
            //var book = await _bookRepository.GetByTitleAsync(title);
            //return book == null;

            return false;
        }

    }
}
