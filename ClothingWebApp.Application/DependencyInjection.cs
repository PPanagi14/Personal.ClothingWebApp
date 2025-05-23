using Microsoft.Extensions.DependencyInjection;
using ClothingWebApp.Application.Services;
using MediatR;
using AutoMapper;
using System.Reflection;
using ClothingWebApp.Application.Behaviors;
using FluentValidation;


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

            // Register all validators automatically
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Register the ValidationBehavior pipeline
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
