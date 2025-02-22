using ClothingWebApp.Application.Features.Product.DTOs;
using MediatR;

namespace ClothingWebApp.Application.Features.Product.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public long Id {get;set;}
    }
}
