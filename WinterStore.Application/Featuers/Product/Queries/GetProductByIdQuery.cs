using AutoMapper;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WinterStore.Application.Common.Interfaces;

namespace WinterStore.Application.Featuers.Product.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Result<ProductResponse>>;

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Result<ProductResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.Id, cancellationToken);

            if (product is null)
            {
                return Result.Fail($"Product with Id {request.Id} was not found.");
            }

            var response = _mapper.Map<ProductResponse>(product);

            return Result.Ok(response);
        }
    }
}
