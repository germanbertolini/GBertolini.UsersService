using AutoMapper;
using GBertolini.UsersService.Business.Users.Interfaces;
using GBertolini.UsersService.Models.Dto;
using GBertolini.UsersService.Models.Factories;
using GBertolini.UsersService.Models.Models;
using GBertolini.UsersService.Models.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBertolini.UsersService.Business.Users.Implementation
{
    public class UsersBusiness : IUsersBusiness
    {
        private readonly IMapper _mapper;

        public UsersBusiness(IMapper mapper)
        {
            _mapper = mapper;   
        }

        public Task<UserDto> Create(UserDto userDto)
        {
            IUser userModel = UserFactory.Create(_mapper, userDto);

            return Task.FromResult(userDto);
        }
    }
}
