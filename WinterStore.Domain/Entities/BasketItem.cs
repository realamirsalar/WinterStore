using System;
using System.Collections.Generic;
using System.Text;

namespace WinterStore.Domain.Entities
{
    public class BasketItem
    {
        private BasketItem() { }

        internal BasketItem(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public int Id { get; private set; }
        public int Quantity { get; private set; }
        public int ProductId { get; private set; }
        public Product? Product { get; private set; }

        public int BasketId { get; private set; }
        public Basket? Basket { get; private set; }

        internal void IncreaseQuantity(int quantity)
        {
            Quantity += quantity;
        }
    }
}
