using AutoMapper;
using ClothingWebApp.Application.Features.Product.Commands.CreateProduct;
using ClothingWebApp.Domain.Entities;
using ClothingWebApp.Application.Features.Product.DTOs;
using ClothingWebApp.Application.Features.User.Commands.CreateUser;
using ClothingWebApp.Application.Features.User.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Maps command to entity
        CreateMap<CreateProductCommand, Product>();
        CreateMap<CreateUserCommand, User>();


        // Maps entity to DTO
        CreateMap<Product, ProductDto>();
        CreateMap<User, UserDto>();
    }
}
