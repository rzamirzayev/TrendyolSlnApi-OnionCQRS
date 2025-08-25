using MediatR;
using Microsoft.EntityFrameworkCore;
using TrendyolSln.Application.DTOs;
using TrendyolSln.Application.Interfaces.AutoMapper;
using TrendyolSln.Application.Interfaces.UnitOfWorks;
using TrendyolSln.Domain.Entities;

namespace TrendyolSln.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductQueryRequest, IList<GetAllProductQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(include:p=>p.Include(b=>b.Brand));

            //List<GetAllProductQueryResponse> response = new List<GetAllProductQueryResponse>();
            //foreach (var product in products) 
            //{
            //    response.Add(new GetAllProductQueryResponse
            //    {
            //        Title = product.Title,
            //        Description = product.Description,
            //        Discount = product.Discount,
            //        Price = product.Price-(product.Price*product.Discount/100),
            //    });

            //}
            mapper.Map<BrandDto, Brand>(new Brand());
            var map = mapper.Map<GetAllProductQueryResponse, Product>(products);
            foreach(var item in map)
                item.Price-=(item.Price * item.Discount / 100);
            return map;

        }
    }
}
