using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WinterStore.Application.Common.Interfaces;

namespace WinterStore.Application.Featuers.Basket.Commands
{
    public class AddItemToBasketCommand : IRequest<Result>
    {
        public AddItemToBasketCommand(string basketId, int productId, int quntity)
        {
            BasketId = basketId;
            ProductId = productId;
            Quntity = quntity;
        }

        public string BasketId { get; set; }
        public int ProductId { get; set; }
        public int Quntity { get; set; }
    }
    public class AddItemToBasketCommandHandler : IRequestHandler<AddItemToBasketCommand, Result>
    {
        private readonly IBasketRepository _basketRepository;

        public AddItemToBasketCommandHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public Task<Result> Handle(AddItemToBasketCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
