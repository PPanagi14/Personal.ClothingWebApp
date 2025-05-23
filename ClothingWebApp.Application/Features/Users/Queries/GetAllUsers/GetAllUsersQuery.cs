

using ClothingWebApp.Application.Features.Users.DTOs;
using MediatR;

namespace ClothingWebApp.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery:IRequest<List<UserDto>>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
    }
}
