using FluentAssertions;
using GBertolini.UsersService.DataAccess.Repositories;
using GBertolini.UsersService.DataAccess.UnitTests.Helpers;
using GBertolini.UsersService.Models.Enums;
using GBertolini.UsersService.Models.Models.Implementations;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GBertolini.UsersService.DataAccess.UnitTests
{
    public class UsersRepositoryTests
    {
        public UsersRepositoryTests()
        {
            TestHelper.PrepareEnvironment();    
        }

        [Fact]
        public async Task Create_NonExistentUser_FinishWithoutErrors()
        {
            //Arrange
            var dbContext = new UsersDbContext();
            var repository = new UsersRepository(dbContext);
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
            dbContext.Users.Any(TestHelper.PredicateToMatchUser(user)).Should().BeTrue();
        }

        [Fact]
        public async Task FindByNameAndAddressAsync_SearchNonExistentUser_ReturnsNull()
        {
            //Arrange
            var dbContext = new UsersDbContext();
            var repository = new UsersRepository(dbContext);

            //Act
            var searchResult = await repository.FindByNameAndAddressAsync(name: "German Bertolini",
                                                                          address: "Buenos Aires");

            //Assert
            searchResult.Should().BeNull();
        }

        [Fact]
        public async Task FindByNameAndAddressAsync_CreateUserAndThenSearchIt_ReturnsTheUser()
        {
            //Arrange
            var dbContext = new UsersDbContext();
            var repository = new UsersRepository(dbContext);
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
            dbContext.Users.Any(TestHelper.PredicateToMatchUser(user)).Should().BeTrue();
        }
    }
}