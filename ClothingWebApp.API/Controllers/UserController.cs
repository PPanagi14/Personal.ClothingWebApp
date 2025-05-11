using ClothingWebApp.Application.Features.User.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ClothingWebApp.Application.Features.User.Commands.CreateUser;
using ClothingWebApp.Domain.Entities;
using ClothingWebApp.Application.Features.User.Queries.GetAllUsers;


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
    }
}
