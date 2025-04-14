using MediatR;

namespace PointOfSale.Application.Features.OrderFeature.Command
{
    public record UpdateOrderStageCommand(Guid OrderId, string Stage) : IRequest<bool>;
}
