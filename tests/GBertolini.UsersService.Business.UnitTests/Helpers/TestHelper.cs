using AutoMapper;
using GBertolini.UsersService.Models.AutoMapperProfiles;
using GBertolini.UsersService.Models.Dto;
using GBertolini.UsersService.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBertolini.UsersService.Business.UnitTests.Helpers
{
    public static class TestHelper
    {
        /// <summary>
        /// Prepares the environment
        /// </summary>
        public static void PrepareEnvironment()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "UnitTesting");
        }

        /// <summary>
        /// Creates an instance of UserDto using example data
        /// </summary>
        public static UserDto CreateUserDto(decimal money, UserType userType)
            => new UserDto
            {
                Name = "German Bertolini",
                Address = "Buenos Aires, Argentina",
                Email = "german.bertolini@gmail.com",
                Money = money,
                Phone = "1234-1234",
                UserType = userType
            };

        /// <summary>
        /// Instance AutoMapper using the same configuration than injected version
        /// </summary>
        public static IMapper InstanceAutoMapper()
            => MapperConfig.InitializeAutoMapper().CreateMapper();
    }
}
