using AutoMapper;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WinterStore.Application.Common.Errors;
using WinterStore.Application.Common.Interfaces;

namespace WinterStore.Application.Featuers.Product.Queries
{
    public record GetAllProductsQuery() : IRequest<Result<IEnumerable<ProductResponse>>>;

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, Result<IEnumerable<ProductResponse>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<ProductResponse>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllProductsAsync(cancellationToken);
            if (products == null)
            {
                return Result.Fail(new NotFoundError("هیچ محصولی پیدا نشد"));
            }

            var response = _mapper.Map<IEnumerable<ProductResponse>>(products);

            return Result.Ok(response);
        }
    }
}
