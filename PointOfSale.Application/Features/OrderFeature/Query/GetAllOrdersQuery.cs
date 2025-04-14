using MediatR;
using PointOfSale.Application.DTOs;

namespace PointOfSale.Application.Features.OrderFeature.Query
{
    public record GetAllOrdersQuery() : IRequest<List<OrderResponseDto>>;
}
