using FluentAssertions;
using GBertolini.UsersService.DataAccess.Repositories;
using GBertolini.UsersService.DataAccess.UnitTests.Helpers;
using GBertolini.UsersService.Models.Enums;
using GBertolini.UsersService.Models.Models.Implementations;
using System.Linq.Expressions;

namespace GBertolini.UsersService.DataAccess.UnitTests
{
    public class UsersRepositoryTests
    {
        [Fact]
        public async Task Create_NonExistentUser_FinishWithoutErrors()
        {
            //Arrange
            var mockedDbContext = TestHelper.BuildMockedUsersDbContext();
            var repository = new UsersRepository(mockedDbContext);
            var user = new User
            {
                Name = "German Bertolini",
                Address = "Buenos Aires",
                Email = "german.bertolini@gmail.com",
                Money = 120,
                Phone = "1234 1234",
                UserType = UserType.Normal
            };

            //Act
            await repository.CreateAsync(user);


            //Assert
            mockedDbContext.Users.Any(TestHelper.PredicateToMatchUser(user)).Should().BeTrue();
        }
    }
}