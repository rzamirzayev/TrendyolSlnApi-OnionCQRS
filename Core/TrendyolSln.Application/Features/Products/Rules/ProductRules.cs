using TrendyolSln.Application.Bases;
using TrendyolSln.Application.Features.Products.Exceptions;
using TrendyolSln.Domain.Entities;

namespace TrendyolSln.Application.Features.Products.Rules
{
    public class ProductRules:BaseRules
    {
        public Task ProductTitleMustBeNotSame(IList<Product> products,string requestTitle)
        {
            if(products.Any(x=>x.Title==requestTitle)) 
            {
                throw new ProductTitleMustNotBeSameException();
            }
            return Task.CompletedTask;
        }
    }
}
