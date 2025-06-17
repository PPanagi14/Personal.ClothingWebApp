using AutoMapper;
using ClothingWebApp.Application.Features.Products.Commands.CreateProduct;
using ClothingWebApp.Application.Features.Products.DTOs;
using ClothingWebApp.Domain.Entities;
using ClothingWebApp.Domain.Interfaces;
using MediatR;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;   

    public CreateProductHandler(IMapper mapper,IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);

        var savedProduct = await _unitOfWork.Products.AddAsync(product, cancellationToken);
        if (savedProduct == null)
        {
            throw new Exception("Failed to create product");
        }

        await _unitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<ProductDto>(savedProduct);
    }
}
