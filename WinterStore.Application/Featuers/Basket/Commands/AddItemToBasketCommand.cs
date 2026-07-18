using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WinterStore.Application.Common.Errors;
using WinterStore.Application.Common.Interfaces;

namespace WinterStore.Application.Featuers.Basket.Commands
{
    public record AddItemToBasketCommand(string? BasketId , int ProductId , int Quantity ) : IRequest<Result<WinterStore.Domain.Entities.Basket>>
    {

    }
    public class AddItemToBasketCommandHandler : IRequestHandler<AddItemToBasketCommand, Result<WinterStore.Domain.Entities.Basket>>
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

        public async Task<Result<WinterStore.Domain.Entities.Basket>> Handle(AddItemToBasketCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.ProductId, cancellationToken);
            if (product == null)
            {
                return Result.Fail(new NotFoundError($"Product with Id {request.ProductId} was not found."));
            }
            Domain.Entities.Basket? basket = null;
            if (!string.IsNullOrWhiteSpace(request.BasketId))
            {
                basket = await _basketRepository.GetBasketWithItemsAndProduct(request.BasketId, cancellationToken);
            }
            if (basket == null)
            {
                var newBasketId = Guid.NewGuid().ToString();

                basket = new Domain.Entities.Basket(newBasketId);

                // فقط به EF معرفی می‌شود، دیتابیس هنوز درگیر نیست
                await _basketRepository.CreateBasketAsync(basket, cancellationToken);
            }
            basket.AddItem(product.Id, request.Quantity);

            var changes = await _unitOfWork.SevaChangesAsync(cancellationToken);
            if (changes < 1)
            {
                return Result.Fail("Add basket operation failed during database save.");
            }

            return Result.Ok(basket);
        }
    }
}
