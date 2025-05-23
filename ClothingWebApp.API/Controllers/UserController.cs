using ClothingWebApp.Application.Features.Users.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ClothingWebApp.Application.Features.Users.Commands.CreateUser;
using ClothingWebApp.Domain.Entities;
using ClothingWebApp.Application.Features.Users.Queries.GetAllUsers;
using ClothingWebApp.Application.Features.Users.Commands.RegisterUser;
using ClothingWebApp.Application.Exceptions;
using ClothingWebApp.Application.Features.Users.Queries.VerifyUser;


namespace ClothingWebApp.API.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController( IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetAllUsersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetUserById(long id)
        //{
        //    var query = await _mediator.Send(new GetUserByIdQuery() { Id = id });
        //    return Ok(query);
        //}

        [HttpPost("CreateNewUser")]
        public Task<UserDto> CreateUser([FromBody] CreateUserCommand user)
        {
            var response = _mediator.Send(user);
            return response;
        }
        
        [HttpPost("RegisterUser")]
        public Task<UserDto> RegisterUser([FromBody] RegisterUserCommand user)
        {
            var response = _mediator.Send(user);
            return response;
        }
        [HttpPost("verify")]
        public async Task<IActionResult> VerifyUser([FromBody] VerifyUserQuery query)
        {
            try
            {
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (InvalidCredentialsException ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "An unexpected error occurred." });
            }
        }
    }
}
