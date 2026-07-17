using AutoMapper;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WinterStore.Application.Common.Interfaces;

namespace WinterStore.Application.Featuers.Basket.Queries
{
    public class GetBasketByIdQuery : IRequest<Result<BasketReaponse>>
    {
        public string BasketId { get; set; }

        public GetBasketByIdQuery(string basketId)
        {
            BasketId = basketId;
        }
    }
    public class GetBasketByIdQueryHandler : IRequestHandler<GetBasketByIdQuery, Result<BasketReaponse>>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public GetBasketByIdQueryHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<Result<BasketReaponse>> Handle(GetBasketByIdQuery request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetBasketWithItemsAndProduct(request.BasketId);
            var basketResponse = _mapper.Map<BasketReaponse>(basket);
            return Result.Ok(basketResponse);
        }
    }
}
