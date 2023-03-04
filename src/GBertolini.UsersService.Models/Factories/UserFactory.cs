using AutoMapper;
using GBertolini.UsersService.Models.Dto;
using GBertolini.UsersService.Models.Extensions;
using GBertolini.UsersService.Models.Models.Interfaces;

namespace GBertolini.UsersService.Models.Factories
{
    public static class UserFactory
    {
        public static IUser Create(IMapper mapper, UserDto userDto)
        {
            var user = Activator.CreateInstance(userDto.UserType.GetUserClassType()) as IUser;
            mapper.Map<UserDto, IUser>(userDto, user);
            user.ApplyGift();
            return user;
        }
    }
}
