using ClothingWebApp.Application.Features.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingWebApp.Application.Features.Users.Queries.LoginUser
{
    public class LoginUserResult
    {
        public string Token { get; set; } = null!;
        public UserDto User { get; set; } = null!;
    }
}
