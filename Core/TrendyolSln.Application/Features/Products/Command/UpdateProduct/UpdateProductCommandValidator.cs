using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendyolSln.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandValidator:AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductCommandValidator() {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id 0-dan boyuk olmalidir");

            RuleFor(x => x.Title)
           .NotEmpty().WithMessage("Title boş ola bilmez")
           .MaximumLength(30).WithMessage("Title en cox 30 herf olabiler");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description boş ola bilmez")
                .MaximumLength(200).WithMessage("Description en cox 200 herf ola biler");
            RuleFor(x => x.BrandId)
                .GreaterThan(0).WithMessage("BrandId 0-dan boyuk olmalidir");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price 0-dan boyuk olmalidir");

            RuleFor(x => x.Discount)
                .GreaterThanOrEqualTo(0).WithMessage("Discount menfi ola bilmez");

            RuleFor(x => x.CategoryIds)
                .NotEmpty()
                .Must(catrgories => catrgories.Any())
                .WithMessage("CategoryIds boş ola bilmez");
        }
    }
}
