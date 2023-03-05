using AutoMapper;
using GBertolini.UsersService.API.Filters;
using GBertolini.UsersService.Business.Users.Implementation;
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
        private readonly UsersBusiness _business;

        public UsersController(ILogger<UsersController> logger, UsersBusiness business)
        {
            _logger = logger;
            _business = business;
        }

        [HttpPost]
        [ActionName("create")]
        public async Task<ResponseDto> PostCreateAsync([FromBody] UserDto userDto)
        {
            await _business.CreateAsync(userDto);
            return new ResponseDto();
        }
    }
}