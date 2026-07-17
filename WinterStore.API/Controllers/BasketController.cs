using MediatR;
using Microsoft.AspNetCore.Mvc;
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
            var result = await _madiator.Send(new GetBasketByIdQuery(Request.Cookies["basketId"]!));

            return HandleResult(result);
        }
    }
}
