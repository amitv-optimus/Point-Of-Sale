using MediatR;
using PointOfSale.Application.DTOs;

namespace PointOfSale.Application.Features.OrderFeature.Query
{
    public record GetOrdersByUserIdQuery(Guid UserId) : IRequest<List<OrderResponseDto>>;
}
