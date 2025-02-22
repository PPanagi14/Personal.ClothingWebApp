using ClothingWebApp.Application.Features.Product.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClothingWebApp.Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        Task<ProductDto> IRequestHandler<CreateProductCommand, ProductDto>.Handle(CreateProductCommand request, CancellationToken cancellationToken)
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
