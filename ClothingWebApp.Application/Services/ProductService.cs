using ClothingWebApp.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingWebApp.Application.Services
{
    public class ProductService : IProductService
    {
        public Task<IList<ProductModel>> GetProducts()
        {
            var products = new List<ProductModel>
            {
                new() { Id = 1, Name = "T-Shirt", Cost = 20 },
                new() { Id = 2, Name = "Jeans", Cost = 50 }
            };

            return Task.FromResult((IList<ProductModel>)products);
        }
    }
}
