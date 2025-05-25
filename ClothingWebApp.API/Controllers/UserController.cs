using MediatR;
using Microsoft.AspNetCore.Mvc;
using ClothingWebApp.Application.Features.Users.Queries.GetAllUsers;
using Microsoft.AspNetCore.Authorization;


namespace ClothingWebApp.API.Controllers
{
    [Authorize]
    [Route("api/users")]
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

    }
}
