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
        public Task<IList<Product>> GetProducts()
        {
            var products = new List<Product>
            {
                new() { Id = 1, Name = "T-Shirt", Cost = 20 },
                new() { Id = 2, Name = "Jeans", Cost = 50 }
            };

            return Task.FromResult((IList<Product>)products);
        }
    }
}
