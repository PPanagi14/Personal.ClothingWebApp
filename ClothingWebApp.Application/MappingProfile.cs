using AutoMapper;
using ClothingWebApp.Application.Features.Products.Commands.CreateProduct;
using ClothingWebApp.Domain.Entities;
using ClothingWebApp.Application.Features.Products.DTOs;
using ClothingWebApp.Application.Features.Users.Commands.CreateUser;
using ClothingWebApp.Application.Features.Users.DTOs;
using ClothingWebApp.Application.Features.Users.Commands.RegisterUser;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Maps command to entity
        CreateMap<CreateProductCommand, Product>();
        CreateMap<CreateUserCommand, User>();
        CreateMap<RegisterUserCommand, User>();


        // Maps entity to DTO
        CreateMap<Product, ProductDto>();
        CreateMap<User, UserDto>();
    }
}
