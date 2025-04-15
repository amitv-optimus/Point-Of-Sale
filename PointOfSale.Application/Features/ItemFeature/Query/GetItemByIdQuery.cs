using MediatR;
using PointOfSale.Application.DTOs;

namespace PointOfSale.Application.Features.ItemFeature.Query
{
    public record GetItemByIdQuery(Guid Id) : IRequest<ItemResponseDto>;
}
