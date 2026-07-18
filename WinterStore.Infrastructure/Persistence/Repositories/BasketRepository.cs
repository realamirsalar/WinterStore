using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WinterStore.Application.Common.Interfaces;
using WinterStore.Domain.Entities;
using WinterStore.Infrastructure.Data;

namespace WinterStore.Infrastructure.Persistence.Repositories
{
    internal class BasketRepository : IBasketRepository
    {
        private readonly WinterDbContext _db;

        public BasketRepository(WinterDbContext db)
        {
            _db = db;
        }

        public async Task AddItemToBasket(int basketId, int productId, int quntity, CancellationToken cancellationToken = default)
        {
            var Item = new BasketItem()
            {
                BasketId = basketId,
                Quantity = quntity,
                ProductId = productId
            };
            await _db.BasketItems.AddAsync(Item , cancellationToken);
        }

        public async Task<Basket> CreateBasket(CancellationToken cancellationToken = default)
        {
            var basketId = Guid.NewGuid().ToString();
            var basket = new Basket { BasketId = basketId };
            await _db.Baskets.AddAsync(basket,cancellationToken);
            return basket;
        }

        public async Task<Basket?> GetBasketWithItemsAndProduct(string basketId, CancellationToken cancellationToken = default)
        {
            return await _db.Baskets.AsNoTracking().Include(b => b.Items).ThenInclude(i => i.Product).FirstOrDefaultAsync(b => b.BasketId == basketId , cancellationToken);
        }

    }
}
