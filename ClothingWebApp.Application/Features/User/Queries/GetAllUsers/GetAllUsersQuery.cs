

using ClothingWebApp.Application.Features.User.DTOs;
using MediatR;

namespace ClothingWebApp.Application.Features.User.Queries.GetAllUsers
{
    public class GetAllUsersQuery:IRequest<List<UserDto>>
    {
    }
}
