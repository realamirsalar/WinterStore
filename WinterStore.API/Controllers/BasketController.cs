using MediatR;
using Microsoft.AspNetCore.Mvc;
using WinterStore.Application.Common.Utility;
using WinterStore.Application.Featuers.Basket.Commands;
using WinterStore.Application.Featuers.Basket.Queries;

namespace WinterStore.API.Controllers
{
    [Route("api/basket")]
    public class BasketController : ApiControllerBase
    {
        private readonly ISender _madiator;

        public BasketController(ISender madiator)
        {
            _madiator = madiator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var result = await _madiator.Send(new GetBasketByIdQuery(Request.Cookies[SD.BasketIdInCookie]!));

            return HandleResult(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddItemToBasket([FromQuery] int productId, [FromQuery] int quntity)
        {
            var result = await _madiator.Send(new AddItemToBasketCommand(Request.Cookies[SD.BasketIdInCookie],productId , quntity));

            if (result.IsSuccess)
            {
                var cookieOptions = new CookieOptions
                {
                    IsEssential = true,
                    Expires = DateTime.UtcNow.AddDays(30)
                };
                Response.Cookies.Append(SD.BasketIdInCookie, result.Value.BasketId, cookieOptions);
                return CreatedAtAction(nameof(GetBasket), result.Value);
            }

            return HandleFailure(result);
        }
    }
}
