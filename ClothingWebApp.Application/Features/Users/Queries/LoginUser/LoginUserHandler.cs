using AutoMapper;
using ClothingWebApp.Application.Exceptions;
using ClothingWebApp.Application.Features.Users.DTOs;
using ClothingWebApp.Application.Services;
using ClothingWebApp.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClothingWebApp.Application.Features.Users.Queries.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserQuery, LoginUserResult>
    {
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;

        public LoginUserHandler( IMapper mapper, ITokenService tokenService,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
        }
        public async Task<LoginUserResult> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _unitOfWork.Users.GetUserByEmailAsync(request.Email);
                var isValid = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
                if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                    throw new InvalidCredentialsException();

                var userRoles = await _unitOfWork.UserRoles.GetUserRolesByUserId(user.Id);

                var claims = new List<Claim>
                {
                    new Claim("email", user.Email),
                    new Claim("id", user.Id.ToString()),
                    new Claim("name", $"{user.FirstName} {user.LastName}")

                };

                foreach (var role in userRoles)
                {
                    claims.Add(new Claim("role", role.Name));

                }

                var token = _tokenService.GenerateToken(claims);

                var userDto = _mapper.Map<UserDto>(user);

                return new LoginUserResult
                {
                    Token = token,
                    User = userDto
                };
            }
            catch (Exception ex)
            {
                // Optionally log the error
                throw new Exception("Login failed", ex);
            }
        }

    }
}
