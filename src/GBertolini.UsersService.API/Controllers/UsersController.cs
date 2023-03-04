using GBertolini.UsersService.API.Filters;
using GBertolini.UsersService.Models.Dto;
using GBertolini.UsersService.Models.Dto.Response;
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
        public Task<ResponseDto<UserDto>> PostCreateAsync([FromBody] UserDto userDto)
        {
            return Task.FromResult(new ResponseDto<UserDto>(new UserDto()));
        }
    }
}