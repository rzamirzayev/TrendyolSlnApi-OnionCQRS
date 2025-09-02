using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendyolSln.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommandValidator:AbstractValidator<RefreshTokenCommandRequest>
    {
        public RefreshTokenCommandValidator() 
        {
            RuleFor(x => x.RefreshToken)
                .NotEmpty()
                .WithMessage("RefreshToken is required.")
                .WithName("refresh token");

            RuleFor(x=>x.AccessToken)
                .NotEmpty()
                .WithMessage("AccessToken is required.")
                .WithName("access token");


        }

    }
}
