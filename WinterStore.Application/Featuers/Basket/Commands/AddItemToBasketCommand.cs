using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WinterStore.Application.Common.Errors;
using WinterStore.Application.Common.Interfaces;

namespace WinterStore.Application.Featuers.Basket.Commands
{
    public class AddItemToBasketCommand : IRequest<Result<string>>
    {
        public AddItemToBasketCommand(string? basketId , int productId, int quntity)
        {
            BasketId = basketId;
            ProductId = productId;
            Quntity = quntity;
        }

        public string? BasketId { get; set; }
        public int ProductId { get; set; }
        public int Quntity { get; set; }
    }
    public class AddItemToBasketCommandHandler : IRequestHandler<AddItemToBasketCommand, Result<string>>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddItemToBasketCommandHandler(IBasketRepository basketRepository, IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public async Task<Result<string>> Handle(AddItemToBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetBasketWithItemsAndProduct(request.BasketId, cancellationToken);
            if (basket == null)
            {
                basket = await _basketRepository.CreateBasket(cancellationToken);
                var changes = await _unitOfWork.SevaChangesAsync(cancellationToken);
                if (changes < 1)
                {
                    return Result.Fail("add basket operation was failed");
                }
            }
            var product = await _productRepository.GetProductByIdAsync(request.ProductId, cancellationToken);
            if (product == null)
            {
                return Result.Fail(new NotFoundError($"Product with Id {request.ProductId} was not found."));
            }
            await _basketRepository.AddItemToBasket(basket.Id, product.Id, request.Quntity,cancellationToken);
            var newchanges = await _unitOfWork.SevaChangesAsync(cancellationToken);
            if (newchanges < 1)
            {
                return Result.Fail("add basket operation was failed");
            }
            return Result.Ok(basket.BasketId);
        }
    }
}
