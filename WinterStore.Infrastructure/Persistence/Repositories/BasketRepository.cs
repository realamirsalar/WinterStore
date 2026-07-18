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

        public async Task<Basket> CreateBasketAsync(Basket basket,CancellationToken cancellationToken = default)
        {
            await _db.Baskets.AddAsync(basket,cancellationToken);
            return basket;
        }

        public async Task<Basket?> GetBasketWithItemsAndProduct(string basketId, CancellationToken cancellationToken = default)
        {
            return await _db.Baskets.Include(b => b.Items).ThenInclude(i => i.Product).FirstOrDefaultAsync(b => b.BasketId == basketId , cancellationToken);
        }

    }
}
