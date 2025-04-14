using MediatR;
using PointOfSale.Application.DTOs;
using PointOfSale.Domain.Entities;

namespace PointOfSale.Application.Features.ItemFeature.Command
{
    //ItemDto will be inside the request object in the handler
    public record AddItemCommand(ItemDto ItemDto) : IRequest<Item>;
}
