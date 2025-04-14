using MediatR;
using PointOfSale.Application.DTOs;

namespace PointOfSale.Application.Features.UserFeature.Query
{
    public record GetAllUsersQuery() : IRequest<List<UserResponseDto>>;
}
