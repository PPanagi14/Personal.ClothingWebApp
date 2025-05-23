using AutoMapper;
using ClothingWebApp.Application.Features.Users.DTOs;
using ClothingWebApp.Domain.Entities;
using ClothingWebApp.Domain.Interfaces;
using MediatR;
using BCrypt;


namespace ClothingWebApp.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserHandler(IMapper mapper, IUnitOfWork unitOfWork,IUserRepository userRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
        public async Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            User newUser = _mapper.Map<User>(request);
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var savedUser = await _userRepository.AddAsync(newUser, cancellationToken);

            if (savedUser == null)
            {
                throw new Exception("Failed to create user");
            }

            await _unitOfWork.CommitAsync(cancellationToken);

            // Return result
            return _mapper.Map<UserDto>(savedUser);
        }

    }
}
