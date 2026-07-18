using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WinterStore.Application.Common.Interfaces;

namespace WinterStore.Application.Featuers.Basket.Commands
{
    public record DeleteBasketCommand(string BasketId) : IRequest<Result>;

    public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand, Result>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBasketCommandHandler(IBasketRepository basketRepository, IUnitOfWork unitOfWork)
        {
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            await _basketRepository.DeleteBasket(request.BasketId);
            var changes = await _unitOfWork.SevaChangesAsync(cancellationToken);
            if (changes > 0)
            {
                return Result.Ok();
            }
            return Result.Fail("delete opetaion was faild");
        }
    }
}
