using AutoMapper;
using GBertolini.UsersService.Business.Exceptions;
using GBertolini.UsersService.Business.Users.Interfaces;
using GBertolini.UsersService.DataAccess.Repositories;
using GBertolini.UsersService.Models.Dto;
using GBertolini.UsersService.Models.Extensions;
using GBertolini.UsersService.Models.Factories;
using GBertolini.UsersService.Models.Models.Implementations;
using GBertolini.UsersService.Models.Models.Interfaces;
using System.Net;

namespace GBertolini.UsersService.Business.Users.Implementation
{
    public class UsersBusiness : IUsersBusiness
    {
        private readonly IMapper _mapper;
        private readonly UsersRepository _repository;

        public UsersBusiness(IMapper mapper, UsersRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task CreateAsync(UserDto userDto)
        {
            IUser user = UserFactory.Create(_mapper, userDto);

            if (await _repository.FindByNameAndAddressAsync(user.Name, user.Address) != null ||
                await _repository.FindByEmailOrPhoneAsync(user.Email, user.Phone) != null)
                throw new BusinessException(HttpStatusCode.Conflict, "User is duplicated.");

            var persistableModel = (User)user;
            persistableModel.UserType = user.ToEnum();

            await _repository.CreateAsync(persistableModel);
        }
    }
}
