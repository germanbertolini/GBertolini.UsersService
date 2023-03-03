using GBertolini.UsersService.API.Filters;
using GBertolini.UsersService.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace GBertolini.UsersService.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [ServiceFilter(typeof(ValidateInputModelAttribute))]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [ActionName("create")]
        public Task<UserDto> PostCreateAsync([FromBody] UserDto userDto)
        {
            return Task.FromResult(new UserDto());
        }
    }
}