using AutoMapper;
using MediatR;
using PointOfSale.Application.DTOs;
using PointOfSale.Application.Features.UserFeature.Query;
using PointOfSale.Application.Interfaces;

namespace PointOfSale.Application.Features.UserFeature.Handler
{
    public class UserLoginQueryHandler(IUserRepository userRepository, IMapper mapper, IPasswordHashService passwordHashService, ITokenService tokenService) : IRequestHandler<UserLoginQuery, UserLoginResponseDto>
    {
        public async Task<UserLoginResponseDto> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {
            var userLoginDto = request.UserLoginDto;
            var user = await userRepository.GetUserByUserName(userLoginDto.UserName);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            if (!passwordHashService.VerifyPassword(userLoginDto.Password, user.Password))
            {
                throw new Exception("Invalid password");
            }
            var userResponseDto = mapper.Map<UserResponseDto>(user);
            var token = tokenService.GenerateToken(user);
            var result = new UserLoginResponseDto
            {
                User = userResponseDto,
                Token = token
            };
            return result;
        }
    }
}
