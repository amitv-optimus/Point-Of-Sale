using MediatR;
using PointOfSale.Application.DTOs;

namespace PointOfSale.Application.Features.ItemFeature.Command
{
    public record UpdateItemCommand(Guid Id, UpdateItemDto UpdateItemDto) : IRequest<Guid>;
}
