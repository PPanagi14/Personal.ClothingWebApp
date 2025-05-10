using ClothingWebApp.Application.Features.User.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ClothingWebApp.Application.Features.User.Commands.CreateUser;


namespace ClothingWebApp.API.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController( IMediator mediator)
        {
            _mediator = mediator;
        }
        //[HttpGet("GetAllUsers")]
        //public IActionResult GetAllUsers()
        //{
        //    return Ok(_userService.GetUsers());
        //}
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
