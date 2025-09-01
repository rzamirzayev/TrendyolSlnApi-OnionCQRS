using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolSln.Application.Features.Products.Rules;
using TrendyolSln.Application.Interfaces.UnitOfWorks;
using TrendyolSln.Domain.Entities;

namespace TrendyolSln.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProductRules productRules;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork,ProductRules productRules)
        {
            _unitOfWork = unitOfWork;
            this.productRules=productRules;
        }
        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync(p => p.Title == request.Title);
            await productRules.ProductTitleMustBeNotSame(products, request.Title);

            Product product=new(request.Title,request.Description, request.BrandId, request.Price, request.Discount);
            await _unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            if(await _unitOfWork.saveAsync() > 0)
            {
                if (request.CategoryIds != null && request.CategoryIds.Count > 0)
                {
                    List<ProductCategory> productCategories = new();
                    foreach (var categoryId in request.CategoryIds)
                    {
                        await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new() { ProductId = product.Id, CategoryId = categoryId });
                    }
                    await _unitOfWork.saveAsync();
                }
            }
            return Unit.Value;
        }
    }
}
