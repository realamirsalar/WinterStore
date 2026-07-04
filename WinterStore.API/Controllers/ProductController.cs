using MediatR;
using Microsoft.AspNetCore.Mvc;
using WinterStore.Application.Featuers.Product.Queries;

namespace WinterStore.API.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly ISender _mediator;

        public ProductController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProductById(int id, CancellationToken cancellationToken)
        {
            var query = new GetProductByIdQuery(id);

            var result = await _mediator.Send(query, cancellationToken);

            if (result.IsFailed)
            {
                return NotFound(new
                {
                    Message = result.Errors.FirstOrDefault()?.Message ?? "محصول یافت نشد."
                });
            }

            return Ok(result.Value);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllProducts(CancellationToken cancellationToken)
        {
            var query = new GetAllProductsQuery();

            var result = await _mediator.Send(query, cancellationToken);

            if (result.IsFailed)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "خطایی در دریافت لیست محصولات رخ داده است."
                });
            }

            return Ok(result.Value);
        }
    }
}
