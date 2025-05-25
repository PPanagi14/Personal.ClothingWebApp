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
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public LoginUserHandler(IUserRepository userRepository, IConfiguration configuration, IMapper mapper, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
            _tokenService = tokenService;
        }
        public async Task<LoginUserResult> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetUserByEmailAsync(request.Email);
                if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                    throw new InvalidCredentialsException();

                var claims = new[]
                {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.FirstName)
        };
                var key = new SymmetricSecurityKey(
               Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

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
                throw new Exception("Login failed", ex);
            }


        }
    }
}
