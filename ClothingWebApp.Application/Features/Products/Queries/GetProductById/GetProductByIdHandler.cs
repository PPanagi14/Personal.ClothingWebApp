using ClothingWebApp.Application.Features.Products.DTOs;
using MediatR;

namespace ClothingWebApp.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        public Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ProductDto
            {
                Description = "Class",  // Example values
                Name = "Class",
                Cost = 12
            });
        }
    }
}
