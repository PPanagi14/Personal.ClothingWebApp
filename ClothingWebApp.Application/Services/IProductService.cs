using ClothingWebApp.Application.Models;

namespace ClothingWebApp.Application.Services
{
    public interface IProductService
    {
        Task<IList<Product>> GetProducts();
    }
}
