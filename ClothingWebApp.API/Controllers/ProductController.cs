
using ClothingWebApp.Application.Features.Products.Commands.CreateProduct;
using ClothingWebApp.Application.Features.Products.DTOs;
using ClothingWebApp.Application.Features.Products.Queries.GetAllProducts;
using ClothingWebApp.Application.Features.Products.Queries.GetProductById;
using ClothingWebApp.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothingWebApp.API.Controllers
{
    [Authorize]
    [Route("api/products")]
    [ApiController]
    public class ProductController:ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var query = await _mediator.Send(new GetAllProductsQuery());
            return Ok(query);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(long id) 
        {
            var query = await _mediator.Send(new GetProductByIdQuery() { Id = id });
            return Ok(query);
        }

        [HttpPost("CreateNewProduct")]
        public Task<ProductDto> CreateProduct([FromBody] CreateProductCommand product) 
        {
            var response = _mediator.Send(product);
            return response;
        }


    }
}
