using AutoMapper;
using GBertolini.UsersService.Business.UnitTests.Helpers;
using GBertolini.UsersService.Business.Users.Implementation;
using GBertolini.UsersService.DataAccess;
using GBertolini.UsersService.DataAccess.Repositories;
using GBertolini.UsersService.Models.Enums;
using FluentAssertions;
using GBertolini.UsersService.Business.Exceptions;

namespace GBertolini.UsersService.Business.UnitTests
{
    public class UsersBusinessTest
    {
        private readonly IMapper _mapper;

        public UsersBusinessTest()
        {
            TestHelper.PrepareEnvironment();
            _mapper = TestHelper.InstanceAutoMapper();
        }

        [Fact]
        public async Task Create_NonExistentUser_FinishesOk()
        {
            //Arrange
            var dto = TestHelper.CreateUserDto(money: 120, userType: UserType.Normal);
            var dbContext = new UsersDbContext();
            var repository = new UsersRepository(dbContext);
            var business = new UsersBusiness(_mapper, repository);

            //Act
            Func<Task> act = async () => {
                await business.CreateAsync(dto);
            };

            //Assert
            act.Should().NotThrowAsync<BusinessException>();
        }
    }
}