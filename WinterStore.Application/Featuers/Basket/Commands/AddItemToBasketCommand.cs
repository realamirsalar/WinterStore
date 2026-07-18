using AutoMapper;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WinterStore.Application.Common.Errors;
using WinterStore.Application.Common.Interfaces;
using WinterStore.Application.Featuers.Basket.Queries;

namespace WinterStore.Application.Featuers.Basket.Commands
{
    public record AddItemToBasketCommand(string? BasketId , int ProductId , int Quantity ) : IRequest<Result<BasketReaponse>>
    {

    }
    public class AddItemToBasketCommandHandler : IRequestHandler<AddItemToBasketCommand, Result<BasketReaponse>>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddItemToBasketCommandHandler(IBasketRepository basketRepository, IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Result<BasketReaponse>> Handle(AddItemToBasketCommand request, CancellationToken cancellationToken)
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

                await _basketRepository.CreateBasketAsync(basket, cancellationToken);
            }
            basket.AddItem(product.Id, request.Quantity);

            var changes = await _unitOfWork.SevaChangesAsync(cancellationToken);
            if (changes < 1)
            {
                return Result.Fail("Add basket operation failed during database save.");
            }
            var basketResponse = _mapper.Map<BasketReaponse>(basket);
            return Result.Ok(basketResponse);
        }
    }
}
