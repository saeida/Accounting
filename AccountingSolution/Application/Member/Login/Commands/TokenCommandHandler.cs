using Domain.Interface.User;
using Domain.Model.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Application.Resources;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Domain.Interface.Jwt;

namespace Application.Member.Login.Commands
{
    public class TokenCommandHandler : IRequestHandler<TokenCommand, TokenResultModel>
    {
      
        private readonly ITokenCommandRepository _tokenCommandRepository;
        private readonly ITokenQueryRepository _tokenQueryRepository;
        
        private readonly IJwtProvider _iJwtProvider;

        public TokenCommandHandler(ITokenCommandRepository tokenCommandRepository, ITokenQueryRepository tokenQueryRepository ,IJwtProvider iJwtProvider)
        {
            _tokenCommandRepository = tokenCommandRepository;
            _tokenQueryRepository = tokenQueryRepository;                 
            _iJwtProvider = iJwtProvider;
        }

        public async Task<TokenResultModel> Handle(TokenCommand request, CancellationToken cancellationToken)
        {

            TokenResultModel trm = new TokenResultModel();
            trm.RefreshToken= request.RefreshToken;
            trm.Token= request.Token;

            var validator = new TokenCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

            RefreshTokenModel storedRefreshToken =await _tokenQueryRepository.FindRefreshToken(request.RefreshToken);
            storedRefreshToken.IsUsed = true;

            var result= await _iJwtProvider.VerifyToken(trm, storedRefreshToken);

           await  _tokenQueryRepository.Update(storedRefreshToken);

            return result;


        }
    }
}
