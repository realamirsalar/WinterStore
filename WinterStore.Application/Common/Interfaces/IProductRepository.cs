using System;
using System.Collections.Generic;
using System.Text;
using WinterStore.Domain.Entities;

namespace WinterStore.Application.Common.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task CreateProductAsync(Product product);
        void UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
