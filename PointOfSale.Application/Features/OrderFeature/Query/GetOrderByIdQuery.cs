using MediatR;
using PointOfSale.Application.DTOs;

namespace PointOfSale.Application.Features.OrderFeature.Query
{
    public record GetOrderByIdQuery(Guid Id) : IRequest<OrderResponseDto>;
}
