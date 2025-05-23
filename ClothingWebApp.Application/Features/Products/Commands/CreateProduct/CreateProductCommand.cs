using ClothingWebApp.Application.Features.Products.DTOs;
using MediatR;

namespace ClothingWebApp.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand :IRequest<ProductDto>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Cost { get; set; }

    }
}
