using MediatR;

namespace PointOfSale.Application.Features.ItemFeature.Command
{
    public record DeleteItemCommand(Guid Id) : IRequest<Guid>;
}
