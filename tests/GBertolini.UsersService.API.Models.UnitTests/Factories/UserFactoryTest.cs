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

namespace GBertolini.UsersService.API.Models.UnitTests.Factories
{
    public class UserFactoryTest
    {
        [Fact]
        public async Task Create_NormalUserType_ReturnsNormalUserInstance()
        {
            //Arrange
            var dto = new UserDto
            {
                Name = "German Bertolini",
                Address = "Buenos Aires, Argentina",
                Email = "german.bertolini@gmail.com",
                Money = 100,
                Phone = "1234-1234",
                UserType = UserType.Normal
            };

            //Act
            var result = UserFactory.Create(dto);

            //Asserts
            result.Should().BeOfType<NormalUser>();
        }
    }
}
