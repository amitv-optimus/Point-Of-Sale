using MediatR;
using PointOfSale.Application.DTOs;

namespace PointOfSale.Application.Features.UserFeature.Command
{
    public record AddUserCommand(UserCreateDto UserCreateDto) : IRequest<UserResponseDto>;
}
