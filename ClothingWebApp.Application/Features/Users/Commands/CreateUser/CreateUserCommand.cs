using MediatR;
using ClothingWebApp.Application.Features.Users.DTOs;

namespace ClothingWebApp.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
    }
}
