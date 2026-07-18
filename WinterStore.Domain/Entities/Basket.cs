using System;
using System.Collections.Generic;
using System.Text;

namespace WinterStore.Domain.Entities
{
    public class Basket
    {
        private readonly List<BasketItem> _items = new();

        private Basket() { }

        public Basket(string basketId)
        {
            if (string.IsNullOrWhiteSpace(basketId))
                throw new ArgumentNullException(nameof(basketId), "BasketId cannot be empty.");

            BasketId = basketId;
        }

        public int Id { get; private set; }
        public string BasketId { get; private set; }

        public IReadOnlyCollection<BasketItem> Items => _items.AsReadOnly();

        public void AddItem(int productId, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));

            var existingItem = _items.FirstOrDefault(i => i.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.IncreaseQuantity(quantity);
            }
            else
            {
                _items.Add(new BasketItem(productId, quantity));
            }
        }
        public void RemoveItem(int productId, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));

            var existingItem = _items.FirstOrDefault(i => i.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.DncreaseQuantity(quantity);
                if (existingItem.Quantity <= 0)
                {
                    _items.Remove(existingItem);
                }
            }

        }
    }

}
