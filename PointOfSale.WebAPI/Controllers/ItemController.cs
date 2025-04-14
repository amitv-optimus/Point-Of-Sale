using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Application.DTOs;
using PointOfSale.Application.Features.ItemFeature.Command;
using PointOfSale.Application.Features.ItemFeature.Query;

namespace PointOfSale.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAllItems")]
        public async Task<IActionResult> GetAllItemsAsync()
        {
            var result = await mediator.Send(new GetAllItemsQuery());
            return Ok(result);
        }
        [HttpPost("AddItem")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddItemAsync([FromBody] ItemDto itemDto)
        {
            var result = await mediator.Send(new AddItemCommand(itemDto));
            return Created("/AddItem", result);
        }
        [HttpPut("UpdateItem/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateItemAsync([FromBody] UpdateItemDto updateItemDto, [FromRoute] Guid id)
        {
            var result = await mediator.Send(new UpdateItemCommand(id, updateItemDto));
            return Ok(result);
        }
        [HttpDelete("DeleteItem/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteItemAsync([FromRoute] Guid id)
        {
            var result = await mediator.Send(new DeleteItemCommand(id));
            return Ok(result);
        }
    }
}
