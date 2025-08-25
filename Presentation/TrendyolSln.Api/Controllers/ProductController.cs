using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrendyolSln.Application.Features.Products.Queries.GetAllProducts;

namespace TrendyolSln.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await mediator.Send(new GetAllProductQueryRequest());
            return Ok(response);
        }
    }
}
