using Microsoft.Extensions.DependencyInjection;
using ClothingWebApp.Application.Services;
using MediatR;

namespace ClothingWebApp.Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

        }
    }
}
