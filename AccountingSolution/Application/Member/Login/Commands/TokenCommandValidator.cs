using Domain.Model.User;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Member.Login.Commands
{
    public class TokenCommandValidator : AbstractValidator<TokenCommand>
    {
        public TokenCommandValidator()
        {
            RuleFor(x => x.Token).NotEmpty();
            RuleFor(x => x.RefreshToken).NotEmpty();

        }
    }
}
