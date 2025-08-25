using MediatR;

namespace TrendyolSln.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductQueryRequest : IRequest<IList<GetAllProductQueryResponse>>
    {
    }
}
