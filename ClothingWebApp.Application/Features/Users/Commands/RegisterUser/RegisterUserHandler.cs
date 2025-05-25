using AutoMapper;
using ClothingWebApp.Application.Features.Users.DTOs;
using ClothingWebApp.Domain.Entities;
using ClothingWebApp.Domain.Interfaces;
using MediatR;
using BCrypt;
using ClothingWebApp.Domain.Enums;


namespace ClothingWebApp.Application.Features.Users.Commands.RegisterUser
{
    
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, UserDto>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserHandler(IMapper mapper, IUnitOfWork unitOfWork,IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        public async Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Email))
                    throw new ArgumentException("Email cannot be null or empty.", nameof(request.Email));

                try
                {
                    // Attempt to find existing user
                    var existingUser = await _userRepository.GetUserByEmailAsync(request.Email);
                    throw new Exception("A user with this email already exists.");
                }
                catch (InvalidOperationException)
                {
                    // Expected — user not found, so continue
                }

                User newUser = _mapper.Map<User>(request);
                newUser.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);

                // Assign default role
                var defaultUserRole = await _roleRepository.GetByNameAsync("User");
                newUser.UserRoles = new List<UserRole>
                {
                    new UserRole { RoleId = defaultUserRole.Id }
                };

                var savedUser = await _userRepository.AddAsync(newUser, cancellationToken);

                if (savedUser == null)
                    throw new Exception("Failed to create user.");

                await _unitOfWork.CommitAsync(cancellationToken);

                return _mapper.Map<UserDto>(savedUser);
            }
            catch (ArgumentException ex)
            {
                // Validation error
                throw new ApplicationException("Validation error: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                // Unexpected errors
                throw new ApplicationException("Registration failed. " + ex.Message, ex);
            }
        }


    }
}
