
using ClothingWebApp.Application.Features.Products.Commands.CreateProduct;
using ClothingWebApp.Application.Features.Products.DTOs;
using ClothingWebApp.Application.Features.Products.Queries.GetProductById;
using ClothingWebApp.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClothingWebApp.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController:ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMediator _mediator;

        public ProductController(IProductService productService,IMediator mediator)
        {
            _productService = productService;
            _mediator = mediator;
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            return Ok(_productService.GetProducts());
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
