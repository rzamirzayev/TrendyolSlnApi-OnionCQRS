using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendyolSln.Application.Features.Auth.Command.Register
{
    public class RegisterCommandValidator:AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator() 
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("FullName is required.")
                .MaximumLength(50)
                .WithMessage("FullName must not exceed 50 characters.")
                .WithName("AD SOYAD");

            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(60)
                .EmailAddress()
                .MinimumLength(8)
                .WithName("Mail adresi");

            RuleFor(x=>x.Password)
                .NotEmpty()
                .MinimumLength(6)
                .WithName("Şifre");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .Equal(x => x.Password)
                .WithMessage("ConfirmPassword must match Password.")
                .WithName("Şifre tekrarı");


        }
    }
}
