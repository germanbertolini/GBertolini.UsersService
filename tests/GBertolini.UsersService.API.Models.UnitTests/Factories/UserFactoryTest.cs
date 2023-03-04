using GBertolini.UsersService.Models.Dto;
using GBertolini.UsersService.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GBertolini.UsersService.Models.Factories;
using FluentAssertions;
using GBertolini.UsersService.Models.Models.Implementation;
using GBertolini.UsersService.API.Models.UnitTests.Helpers;
using GBertolini.UsersService.Models.Extensions;
using AutoMapper;
using GBertolini.UsersService.Models.AutoMapperProfiles;
using GBertolini.UsersService.Models.Sanitizers;

namespace GBertolini.UsersService.API.Models.UnitTests.Factories
{
    public class UserFactoryTest
    {
        private readonly IMapper _mapper;

        public UserFactoryTest()
        {
            _mapper = TestHelper.InstanceAutoMapper();
        }

        [Fact]
        public void UserObjectCreation_NormalUserType_ReturnsNormalUserInstance()
        {
            //Arrange
            var dto = TestHelper.CreateUserDto(money: 100, userType: UserType.Normal);

            //Act
            var result = UserFactory.Create(_mapper, dto);

            //Asserts
            result.Should().BeOfType<NormalUser>();
            result.ToEnum().Should().Be(UserType.Normal);
            result.Name.Should().Be(dto.Name);
            result.Email.Should().Be(EmailSanitizer.Sanitize(dto.Email));
            result.Address.Should().Be(dto.Address);
            result.Phone.Should().Be(dto.Phone);
        }

        [Fact]
        public void UserObjectCreation_PremiumUserType_ReturnsPremiumUserInstance()
        {
            //Arrange
            var dto = TestHelper.CreateUserDto(money: 100, userType: UserType.Premium);

            //Act
            var result = UserFactory.Create(_mapper, dto);

            //Asserts
            result.Should().BeOfType<PremiumUser>();
            result.ToEnum().Should().Be(UserType.Premium);
            result.Name.Should().Be(dto.Name);
            result.Email.Should().Be(EmailSanitizer.Sanitize(dto.Email));
            result.Address.Should().Be(dto.Address);
            result.Phone.Should().Be(dto.Phone);
        }

        [Fact]
        public void UserObjectCreation_SuperUserType_ReturnsSuperUserInstance()
        {
            //Arrange
            var dto = TestHelper.CreateUserDto(money: 100, userType: UserType.SuperUser);

            //Act
            var result = UserFactory.Create(_mapper, dto);

            //Asserts
            result.Should().BeOfType<SuperUser>();
            result.ToEnum().Should().Be(UserType.SuperUser);
            result.Name.Should().Be(dto.Name);
            result.Email.Should().Be(EmailSanitizer.Sanitize(dto.Email));
            result.Address.Should().Be(dto.Address);
            result.Phone.Should().Be(dto.Phone);
        }

        [Fact]
        public void UserObjectCreation_EmailToSanitize_ReturnsEmailWithNormalizedDomain()
        {
            //Arrange
            var dto = TestHelper.CreateUserDto(money: 100, userType: UserType.SuperUser);
            dto.Email = "german.bertolini+German Bertolini@gmail.com";

            //Act
            var result = UserFactory.Create(_mapper, dto);

            //Asserts
            result.Should().BeOfType<SuperUser>();
            result.Email.Should().Be("germanbertolini@gmail.com");
        }

        [Fact]
        public void ApplyGift_NormalUser_WhenMoneyIsGreatherThan100_MoneyHas12PercentageAsGift()
        {
            //Arrange
            var dto = TestHelper.CreateUserDto(money: 120, userType: UserType.Normal);

            //Act
            var result = UserFactory.Create(_mapper, dto);

            //Asserts
            result.Money.Should().Be(120 * (decimal)1.12);
        }

        [Fact]
        public void ApplyGift_NormalUser_WhenMoneyIsLowerThan10_MoneyWithoutGift()
        {
            //Arrange
            var dto = TestHelper.CreateUserDto(money: 3, userType: UserType.Normal);

            //Act
            var result = UserFactory.Create(_mapper, dto);

            //Asserts
            result.Money.Should().Be(3);
        }

        [Fact]
        public void ApplyGift_NormalUser_WhenMoneyIsBetween10And100_MoneyHas80PercentageAsGift()
        {
            //Arrange
            var dto = TestHelper.CreateUserDto(money: 50, userType: UserType.Normal);

            //Act
            var result = UserFactory.Create(_mapper, dto);

            //Asserts
            result.Money.Should().Be(50 * (decimal)1.8);
        }

        [Fact]
        public void ApplyGift_PremiumUser_WhenMoneyIsGreatherThan100_MoneyHas200PercentageAsGift()
        {
            //Arrange
            var dto = TestHelper.CreateUserDto(money: 120, userType: UserType.Premium);

            //Act
            var result = UserFactory.Create(_mapper, dto);

            //Asserts
            result.Money.Should().Be(120 * (decimal)3);
        }

        [Fact]
        public void ApplyGift_PremiumUser_WhenMoneyIsLowerThan100_MoneyWithoutGift()
        {
            //Arrange
            var dto = TestHelper.CreateUserDto(money: 80, userType: UserType.Premium);

            //Act
            var result = UserFactory.Create(_mapper, dto);

            //Asserts
            result.Money.Should().Be(80);
        }

        [Fact]
        public void ApplyGift_SuperUser_WhenMoneyIsGreatherThan100_MoneyHas20PercentageAsGift()
        {
            //Arrange
            var dto = TestHelper.CreateUserDto(money: 120, userType: UserType.SuperUser);

            //Act
            var result = UserFactory.Create(_mapper, dto);

            //Asserts
            result.Money.Should().Be(120 * (decimal)1.2);
        }

        [Fact]
        public void ApplyGift_SuperUser_WhenMoneyIsLowerThan100_MoneyWithoutGift()
        {
            //Arrange
            var dto = TestHelper.CreateUserDto(money: 80, userType: UserType.SuperUser);

            //Act
            var result = UserFactory.Create(_mapper, dto);

            //Asserts
            result.Money.Should().Be(80);
        }
    }
}
