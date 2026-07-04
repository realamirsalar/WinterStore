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


        public async Task<List<Product>> GetAllProductsAsync(CancellationToken cancellationToken = default)
        {
            return await _db.Products
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Product?> GetProductByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _db.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task CreateProductAsync(Product product, CancellationToken cancellationToken = default)
        {
            await _db.Products.AddAsync(product, cancellationToken);
        }

        public void UpdateProduct(Product product)
        {
            _db.Products.Update(product);
        }

        public async Task DeleteProduct(int id, CancellationToken cancellationToken = default)
        {
            await _db.Products
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync(cancellationToken);
        }

    }
}
