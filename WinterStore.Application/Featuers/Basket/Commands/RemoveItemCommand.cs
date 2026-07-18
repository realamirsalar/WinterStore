using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WinterStore.Application.Common.Errors;
using WinterStore.Application.Common.Interfaces;

namespace WinterStore.Application.Featuers.Basket.Commands
{
    public record RemoveItemCommand(string BasketId, int productId, int Quantity) : IRequest<Result>;

    public class RemoveItemCommandHandler : IRequestHandler<RemoveItemCommand, Result>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveItemCommandHandler(IBasketRepository basketRepository, IUnitOfWork unitOfWork)
        {
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RemoveItemCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetBasketWithItemsAndProduct(request.BasketId, cancellationToken);
            if (basket == null)
            {
                return Result.Fail(new NotFoundError($"Basket was not found."));
            }
            var changes = await _unitOfWork.SevaChangesAsync(cancellationToken);
            if (changes > 0)
            {
                return Result.Ok();
            }
            return Result.Fail("opetaion was faild");
        }
    }
}
