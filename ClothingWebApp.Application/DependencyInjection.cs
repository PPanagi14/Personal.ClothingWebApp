using Microsoft.Extensions.DependencyInjection;
using ClothingWebApp.Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;



namespace ClothingWebApp.Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddMediatR(cfg =>
            {
                cfg.AsScoped(); // Example configuration to avoid the error
            }, Assembly.GetExecutingAssembly()); // Specify Assembly explicitly to resolve ambiguity
        }
    }
}
