using System;
using System.Collections.Generic;
using System.Text;
using WinterStore.Domain.Entities;

namespace WinterStore.Application.Common.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync(CancellationToken cancellationToken = default);

        Task<Product?> GetProductByIdAsync(int id, CancellationToken cancellationToken = default);

        Task CreateProductAsync(Product product, CancellationToken cancellationToken = default);

        void UpdateProduct(Product product);

        Task DeleteProduct(int id, CancellationToken cancellationToken = default);
    }
}
