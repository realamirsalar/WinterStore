using System;
using System.Collections.Generic;
using System.Text;
using WinterStore.Domain.Entities;

namespace WinterStore.Application.Common.Interfaces
{
    public interface IBasketRepository
    {
        Task<Basket?> GetBasketWithItemsAndProduct(string basketId, CancellationToken cancellationToken = default);
        Task AddItemToBasket(int basketId, int productId, int quntity, CancellationToken cancellationToken = default);
        Task<Basket> CreateBasket(CancellationToken cancellationToken = default);
    }

}
