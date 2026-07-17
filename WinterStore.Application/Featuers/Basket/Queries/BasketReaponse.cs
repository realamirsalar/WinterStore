using System;
using System.Collections.Generic;
using System.Text;

namespace WinterStore.Application.Featuers.Basket.Queries
{
    public class BasketReaponse
    {
        public int Id { get; set; }
        public required string BasketId { get; set; }
        public List<BasketItemResponse> Items { get; set; } = [];
    }
}
