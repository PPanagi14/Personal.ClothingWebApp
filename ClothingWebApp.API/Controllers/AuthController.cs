using ClothingWebApp.Application.Exceptions;
using ClothingWebApp.Application.Features.Users.Commands.RegisterUser;
using ClothingWebApp.Application.Features.Users.DTOs;
using ClothingWebApp.Application.Features.Users.Queries.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClothingWebApp.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
       

        [HttpPost("registerUser")]
        public Task<UserDto> RegisterUser([FromBody] RegisterUserCommand user)
        {
            var response = _mediator.Send(user);
            return response;
        }

        [HttpPost("logIn")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserQuery query)
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
