using ClothingWebApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClothingWebApp.API.Controllers
{
    public static class ProductEndpoint
    {
        public static void RegisterProductEndpoint(this WebApplication application)
        {
            application.MapGet("/api/GetProducts", (IProductService productService) =>
            {
                return Results.Ok(productService.GetProducts());

            }).WithName("GetAllProducts");
        }

    }
}
