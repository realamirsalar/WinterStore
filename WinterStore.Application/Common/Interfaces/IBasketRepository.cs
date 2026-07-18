using System;
using System.Collections.Generic;
using System.Text;
using WinterStore.Domain.Entities;

namespace WinterStore.Application.Common.Interfaces
{
    public interface IBasketRepository
    {
        Task<Basket?> GetBasketWithItemsAndProduct(string basketId, CancellationToken cancellationToken = default);
        Task<Basket> CreateBasketAsync(Basket basket,CancellationToken cancellationToken = default);
        Task DeleteBasket(string basketId, CancellationToken cancellationToken = default);
    }

}
