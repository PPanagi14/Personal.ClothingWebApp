using ClothingWebApp.Application.Features.Product.DTOs;
using MediatR;

namespace ClothingWebApp.Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommand :IRequest<ProductDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}
