using AutoMapper;
using MediatR;
using PointOfSale.Application.DTOs;
using PointOfSale.Application.Features.UserFeature.Command;
using PointOfSale.Application.Interfaces;
using PointOfSale.Domain.Entities;

namespace PointOfSale.Application.Features.UserFeature.Handler
{
    class AddUserCommandHandler(IUserRepository userRepository, IMapper mapper, IPasswordHashService passwordHashService) : IRequestHandler<AddUserCommand, UserResponseDto>
    {
        public async Task<UserResponseDto> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var userDto = request.UserCreateDto;
            if(userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto), "UserCreateDto cannot be null");
            }
            var existingUser = await userRepository.GetUserByEmail(userDto.Email);
            if (existingUser != null)
            {
                throw new Exception("User with this email already exists");
            }
            existingUser = await userRepository.GetUserByUserName(userDto.UserName);
            if (existingUser != null)
            {
                throw new Exception("User with this username already exists");
            }
            var user = mapper.Map<User>(userDto);
            user.Id = Guid.NewGuid();
            user.Password = passwordHashService.HashPassword(user.Password);
            var addedUser = await userRepository.AddUser(user);
            var result = mapper.Map<UserResponseDto>(addedUser);
            return result;
        }
    }

}
