using MediatR;
using PointOfSale.Application.DTOs;

namespace PointOfSale.Application.Features.OrderFeature.Command
{
    public record CreateOrderCommand(Guid UserId, OrderCreateDto OrderCreateDto) : IRequest<Guid>;
}
