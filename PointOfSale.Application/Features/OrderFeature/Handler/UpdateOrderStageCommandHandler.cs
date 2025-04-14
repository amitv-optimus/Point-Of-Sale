using MediatR;
using PointOfSale.Application.Features.OrderFeature.Command;
using PointOfSale.Application.Interfaces;

namespace PointOfSale.Application.Features.OrderFeature.Handler
{
    class UpdateOrderStageCommandHandler(IOrderRepository orderRepository) : IRequestHandler<UpdateOrderStageCommand, bool>
    {
        public async Task<bool> Handle(UpdateOrderStageCommand request, CancellationToken cancellationToken)
        {
            var orderId = request.OrderId;
            var stage = request.Stage;
            if (orderId == Guid.Empty)
            {
                throw new ArgumentException("Order ID cannot be empty", nameof(orderId));
            }
            if (string.IsNullOrEmpty(stage))
            {
                throw new ArgumentException("Stage cannot be null or empty", nameof(stage));
            }
            var order = await orderRepository.GetOrderById(orderId);
            if (order == null)
            {
                throw new ArgumentException($"Order with ID {orderId} does not exist", nameof(orderId));
            }
            var updatedOrder = await orderRepository.UpdateOrderStage(orderId, stage);
            return updatedOrder != null;
        }
    }
}
