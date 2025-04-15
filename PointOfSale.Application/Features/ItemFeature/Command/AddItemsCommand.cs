using MediatR;
using PointOfSale.Application.DTOs;
using PointOfSale.Domain.Entities;

namespace PointOfSale.Application.Features.ItemFeature.Command
{
    public record AddItemsCommand(ICollection<ItemDto> ItemsDto) : IRequest<ICollection<Item>>;
}
