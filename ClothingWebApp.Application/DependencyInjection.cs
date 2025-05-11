using Microsoft.Extensions.DependencyInjection;
using ClothingWebApp.Application.Services;
using MediatR;
using AutoMapper;
using System.Reflection;


namespace ClothingWebApp.Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();

            // Register MediatR handlers
            services.AddMediatR(cfg =>
            {
                cfg.AsScoped();
            }, Assembly.GetExecutingAssembly());

            // Register AutoMapper profiles
            services.AddAutoMapper(Assembly.GetEntryAssembly());
        }
    }
}
