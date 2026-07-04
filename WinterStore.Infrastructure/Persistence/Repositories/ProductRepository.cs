using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WinterStore.Application.Common.Interfaces;
using WinterStore.Domain.Entities;
using WinterStore.Infrastructure.Data;

namespace WinterStore.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly WinterDbContext _db;

        public ProductRepository(WinterDbContext db)
        {
            _db = db;
        }

        public async Task CreateProductAsync(Product product)
        {
            await _db.Products.AddAsync(product);
        }

        public async Task DeleteProduct(int id)
        {
            var product = await GetProductByIdAsync(id);
            _db.Products.Remove(product);
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _db.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _db.Products.AsNoTracking().SingleOrDefaultAsync(p => p.Id == id);

        }

        public void UpdateProduct(Product product)
        {
            _db.Products.Update(product);
        }
    }
}
