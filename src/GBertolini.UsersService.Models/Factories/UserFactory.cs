using GBertolini.UsersService.Models.Dto;
using GBertolini.UsersService.Models.Extensions;
using GBertolini.UsersService.Models.Models.Implementation;
using GBertolini.UsersService.Models.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBertolini.UsersService.Models.Factories
{
    public static class UserFactory
    {
        public static IUser Create(UserDto userDto)
        {
            var user = Activator.CreateInstance(userDto.UserType.GetUserClassType()) as IUser;
            user.ApplyGift();
            return user;
        }
    }
}
