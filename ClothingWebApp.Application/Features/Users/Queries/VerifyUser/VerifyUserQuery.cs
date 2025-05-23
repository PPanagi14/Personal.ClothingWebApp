using ClothingWebApp.Application.Features.Users.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingWebApp.Application.Features.Users.Queries.VerifyUser
{
    public class VerifyUserQuery :IRequest<UserDto>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
