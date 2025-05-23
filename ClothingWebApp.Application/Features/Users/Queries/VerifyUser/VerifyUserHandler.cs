using AutoMapper;
using ClothingWebApp.Application.Exceptions;
using ClothingWebApp.Application.Features.Users.DTOs;
using ClothingWebApp.Domain.Interfaces;
using MediatR;

namespace ClothingWebApp.Application.Features.Users.Queries.VerifyUser
{
    public class VerifyUserHandler : IRequestHandler<VerifyUserQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public VerifyUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(VerifyUserQuery request, CancellationToken cancellationToken)
        {
            // 1. Fetch user by email
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null)
            {
                throw new NotFoundException($"User with email '{request.Email}' not found.");
            }

            // 2. Verify password
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
            if (!isPasswordValid)
            {
                throw new InvalidCredentialsException();
            }

            // 3. Map User entity to UserDto
            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }
    }

}
