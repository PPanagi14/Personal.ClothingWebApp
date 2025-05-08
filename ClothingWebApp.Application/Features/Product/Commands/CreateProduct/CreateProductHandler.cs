using ClothingWebApp.Application.Features.Product.DTOs;
using MediatR;
using ClothingWebApp.Domain.Interfaces;
using ClothingWebApp.Domain.Entities;
using AutoMapper;



namespace ClothingWebApp.Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private IProductRepository _productRepository;
        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        async Task<ProductDto> IRequestHandler<CreateProductCommand, ProductDto>.Handle(CreateProductCommand productCommand, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = productCommand.Name,
                Price = productCommand.Price,
                Description = productCommand.Description,
                // Map other fields as necessary
            };

            var dbProduct = await _productRepository.AddAsync(product);

            return dbProduct;

        }
    }
}
