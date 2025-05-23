using AutoMapper;
using ClothingWebApp.Application.Features.Users.Commands.CreateUser;
using ClothingWebApp.Application.Features.Users.DTOs;
using ClothingWebApp.Domain.Entities;
using ClothingWebApp.Domain.Interfaces;
using MediatR;


public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserHandler(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            var savedUser = await _userRepository.AddAsync(user, cancellationToken);
            if (savedUser == null)
            {
                throw new Exception("Failed to create user");
            }

            await _unitOfWork.CommitAsync(cancellationToken);

            return _mapper.Map<UserDto>(savedUser);
        }
    }

