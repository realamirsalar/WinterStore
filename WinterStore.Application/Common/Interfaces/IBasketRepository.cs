using System;
using System.Collections.Generic;
using System.Text;
using WinterStore.Domain.Entities;

namespace WinterStore.Application.Common.Interfaces
{
    public interface IBasketRepository
    {
        Task<Basket?> GetBasketWithItemsAndProduct(string basketId);
    }
}
