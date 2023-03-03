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
