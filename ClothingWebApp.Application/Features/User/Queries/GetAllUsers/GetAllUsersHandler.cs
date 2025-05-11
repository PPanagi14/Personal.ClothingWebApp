

using ClothingWebApp.Application.Features.User.DTOs;
using ClothingWebApp.Domain.Interfaces;
using ClothingWebApp.Domain.Entities;
using MediatR;

namespace ClothingWebApp.Application.Features.User.Queries.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            // Fix for CS0118: Ensure the correct namespace and type are used
            IReadOnlyList<ClothingWebApp.Domain.Entities.User> users = await _userRepository.GetAllAsync(cancellationToken);

            // Map User entities to UserDto
            List<UserDto> userDtos = users.Select(user => new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                City = user.City,
                State = user.State,
                ZipCode = user.ZipCode
            }).ToList();

            return userDtos;
        }
    }
}
