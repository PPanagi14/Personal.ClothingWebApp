using AutoMapper;
using ClothingWebApp.Application.Features.Product.Commands.CreateProduct;
using ClothingWebApp.Application.Features.Product.DTOs;
using ClothingWebApp.Domain.Entities;
using ClothingWebApp.Domain.Interfaces;
using MediatR;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;   

    public CreateProductHandler(IProductRepository productRepository, IMapper mapper,IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);

        var savedProduct = await _productRepository.AddAsync(product, cancellationToken);
        if (savedProduct == null)
        {
            throw new Exception("Failed to create product");
        }

        await _unitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<ProductDto>(savedProduct);
    }
}
