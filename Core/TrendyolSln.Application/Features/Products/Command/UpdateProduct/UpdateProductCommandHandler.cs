using MediatR;
using Microsoft.AspNetCore.Http;
using TrendyolSln.Application.Bases;
using TrendyolSln.Application.Interfaces.AutoMapper;
using TrendyolSln.Application.Interfaces.UnitOfWorks;
using TrendyolSln.Domain.Entities;

namespace TrendyolSln.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler :BaseHandler, IRequestHandler<UpdateProductCommandRequest,Unit>
    {

        public UpdateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor):base(mapper, unitOfWork, httpContextAccessor)
        {
        }
        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x=>x.Id==request.Id && !x.IsDeleted);

            var map= mapper.Map<Product, UpdateProductCommandRequest>(request);

            var productCategories=await unitOfWork.GetReadRepository<ProductCategory>()
                .GetAllAsync(x => x.ProductId == request.Id);

            await unitOfWork.GetWriteRepository<ProductCategory>().HardDeleteRangeAsync(productCategories);

            foreach (var categoryId in request.CategoryIds)
            { 
                await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new() { ProductId = product.Id, CategoryId = categoryId });
            }
            await unitOfWork.GetWriteRepository<Product>().UpdateAsync(map);
            await unitOfWork.saveAsync();
            return Unit.Value;
        }
    }
}
