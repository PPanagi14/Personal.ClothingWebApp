using ClothingWebApp.Application.Features.Product.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingWebApp.Application.Features.Product.Queries.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        public Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ProductDto
            {
                Description = "Class",  // Example values
                Name = "Class",
                Price = 12
            });
        }
    }
}
