using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolSln.Application.Interfaces.UnitOfWorks;
using TrendyolSln.Domain.Entities;

namespace TrendyolSln.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
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
        }
    }
}
