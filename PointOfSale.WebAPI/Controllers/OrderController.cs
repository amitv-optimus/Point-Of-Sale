using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Application.DTOs;
using PointOfSale.Application.Features.OrderFeature.Command;
using PointOfSale.Application.Features.OrderFeature.Query;
using System.Security.Claims;

namespace PointOfSale.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IMediator mediator) : ControllerBase
    {
        [HttpPost("CreateOrder")]
        [Authorize]
        public async Task<IActionResult> CreateOrderAsync([FromBody] OrderCreateDto orderCreateDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }
            var userIdGuid = Guid.Parse(userId);
            var result = await mediator.Send(new CreateOrderCommand(userIdGuid, orderCreateDto));
            return Created("/Order", result);
        }
        [HttpGet("GetAllOrders")]
        [Authorize(Roles="Admin,Cashier")]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            var result = await mediator.Send(new GetAllOrdersQuery());
            return Ok(result);
        }
        [HttpGet("GetOrder/{id}")]
        [Authorize]
        public async Task<IActionResult> GetOrderByIdAsync(Guid id)
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            var result = await mediator.Send(new GetOrderByIdQuery(id));
            if (result == null)
            {
                return NotFound();
            }
            if (userRole == "Customer")
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                {
                    return Unauthorized();
                }
                var userIdGuid = Guid.Parse(userId);
    
                if (result.UserId != userIdGuid)
                {
                    return Forbid();
                }
            }
            return Ok(result);
        }
        [HttpGet("GetOrdersByUserId/{userId}")]
        [Authorize]
        public async Task<IActionResult> GetOrdersByUserIdAsync(Guid userId)
        {
            var result = await mediator.Send(new GetOrdersByUserIdQuery(userId));
            if (result == null)
            {
                return NotFound();
            }
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            if (userRole == "Customer")
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim == null)
                {
                    return Unauthorized();
                }
                var userIdClaimGuid = Guid.Parse(userIdClaim);
                if (userId != userIdClaimGuid)
                {
                    return Forbid();
                }
            }
            return Ok(result);
        }
        [HttpPut("UpdateOrderStage/{id}")]
        [Authorize(Roles = ("Admin,Cashier"))]
        public async Task<IActionResult> UpdateOrderStageAsync(Guid id, [FromBody] string stage)
        {
            var result = await mediator.Send(new UpdateOrderStageCommand(id, stage));
            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
