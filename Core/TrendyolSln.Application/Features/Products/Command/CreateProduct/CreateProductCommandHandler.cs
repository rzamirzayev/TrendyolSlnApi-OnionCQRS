using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolSln.Application.Bases;
using TrendyolSln.Application.Features.Products.Rules;
using TrendyolSln.Application.Interfaces.AutoMapper;
using TrendyolSln.Application.Interfaces.UnitOfWorks;
using TrendyolSln.Domain.Entities;

namespace TrendyolSln.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler :BaseHandler, IRequestHandler<CreateProductCommandRequest,Unit>
    {
        private readonly ProductRules productRules;

        public CreateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ProductRules productRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.productRules=productRules;
        }
        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(p => p.Title == request.Title);
            await productRules.ProductTitleMustBeNotSame(products, request.Title);

            Product product=new(request.Title,request.Description, request.BrandId, request.Price, request.Discount);
            await unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            if(await unitOfWork.saveAsync() > 0)
            {
                if (request.CategoryIds != null && request.CategoryIds.Count > 0)
                {
                    List<ProductCategory> productCategories = new();
                    foreach (var categoryId in request.CategoryIds)
                    {
                        await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new() { ProductId = product.Id, CategoryId = categoryId });
                    }
                    await unitOfWork.saveAsync();
                }
            }
            return Unit.Value;
        }
    }
}
