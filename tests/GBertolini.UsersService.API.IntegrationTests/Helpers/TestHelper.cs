using GBertolini.UsersService.Models.Dto;
using GBertolini.UsersService.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBertolini.UsersService.API.IntegrationTests.Helpers
{
    public static class TestHelper
    {
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
        /// Create an instance of HttpContent to send json content
        /// </summary>
        public static HttpContent BuildJsonContent(object payload)
            => new StringContent(JsonConvert.SerializeObject(payload), UnicodeEncoding.UTF8, "application/json");

        /// <summary>
        /// Try to read HttpResponseMessage. If it fails, the returned value will be the default for TResult.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        public static async Task<TResult> TryToReadResponseAsync<TResult>(HttpResponseMessage response)
        {
            TResult content = default;
            try
            {
                var responseStr = await response.Content.ReadAsStringAsync();
                content = JsonConvert.DeserializeObject<TResult>(responseStr);
            }
            catch { }
            return content;
        }
    }
}
