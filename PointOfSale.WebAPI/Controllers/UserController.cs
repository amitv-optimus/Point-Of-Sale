using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Application.DTOs;
using PointOfSale.Application.Features.UserFeature.Command;
using PointOfSale.Application.Features.UserFeature.Query;

namespace PointOfSale.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserCreateDto userCreateDto)
        {
            var result = await mediator.Send(new AddUserCommand(userCreateDto));
            return Created("/Register", result);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginDto userLoginDto)
        {
            var result = await mediator.Send(new UserLoginQuery(userLoginDto));
            return Ok(result);
        }

        [HttpGet("GetAllUsers")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
           
            var result = await mediator.Send(new GetAllUsersQuery());
            return Ok(result);
        }
    }
}
