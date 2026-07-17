using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WinterStore.Application.Featuers.Basket.Queries;
using WinterStore.Application.Featuers.Product.Queries;
using WinterStore.Domain.Entities;

namespace WinterStore.Application.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductResponse>();
            CreateMap<Basket, BasketReaponse>();
            CreateMap<BasketItem, BasketItemResponse>();
        }
    }
}
