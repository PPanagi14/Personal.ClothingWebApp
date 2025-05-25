using AutoMapper;
using ClothingWebApp.Application.Features.Products.DTOs;
using ClothingWebApp.Domain.Interfaces;
using MediatR;

namespace ClothingWebApp.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetAllProductsHandler(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            
            var products= await _productRepository.GetAllAsync();
            if (products == null || !products.Any())
            {
                return new List<ProductDto>();
            }
            
            return _mapper.Map<List<ProductDto>>(products);

        }
    }
}
