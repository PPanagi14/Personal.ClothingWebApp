using ClothingWebApp.Application.Features.Products.DTOs;
using MediatR;

namespace ClothingWebApp.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public long Id {get;set;}
    }
}
