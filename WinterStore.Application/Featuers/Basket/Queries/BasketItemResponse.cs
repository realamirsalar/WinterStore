using System;
using System.Collections.Generic;
using System.Text;
using WinterStore.Application.Featuers.Product.Queries;

namespace WinterStore.Application.Featuers.Basket.Queries
{
    public class BasketItemResponse
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public ProductResponse? Product { get; set; }
    }
}
