using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendyolSln.Application.Features.Auth.Command.Revoke
{
    public class RevokeCommandValidator:AbstractValidator<RevokeCommandRequest>
    {
        public RevokeCommandValidator()
        {
            RuleFor(x=>x.Email)
                .EmailAddress()
                .NotEmpty()
                .WithMessage("Email is required and must be a valid email address.")
        }
    }
}
