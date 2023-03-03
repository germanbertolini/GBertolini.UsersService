using FluentAssertions;
using GBertolini.UsersService.API.Controllers;
using GBertolini.UsersService.API.IntegrationTests.Helpers;
using GBertolini.UsersService.Models.Dto;
using GBertolini.UsersService.Models.Enums;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace GBertolini.UsersService.API.IntegrationTests
{
    public class UsersControllerTests
    {
        private readonly HttpClient _httpClient;
        
        public UsersControllerTests()
        {
            var factory = new WebApplicationFactory<UsersController>();
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task Create_MissingOneField_ReturnsBadRequestWithOneError()
        {
            //Arrange
            var payload = new UserDto
            {
                Name = null,
                Address = "Buenos Aires, Argentina",
                Email = "german.bertolini@gmail.com",
                Money = 100,
                Phone = "1234-1234",
                UserType = UserType.Normal
            };

            //Act
            var response = await _httpClient.PostAsync("/users/create", TestHelper.BuildJsonContent(payload));
            var responseObj = await TestHelper.TryToReadResponseAsync<ErrorResponseDto>(response);

            //Asserts
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            responseObj.Errors.Count.Should().Be(1);
        }

        [Fact]
        public async Task Create_MissingFourFields_ReturnsBadRequestWithMultipleErrors()
        {
            //Arrange
            var payload = new UserDto
            {
                Name = null,
                Address = null,
                Email = null,
                Phone = null
            };

            //Act
            var response = await _httpClient.PostAsync("/users/create", TestHelper.BuildJsonContent(payload));
            var responseObj = await TestHelper.TryToReadResponseAsync<ErrorResponseDto>(response);

            //Asserts
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            responseObj.Errors.Count.Should().Be(4);
        }

        [Fact]
        public async Task Create_EmptyPayload_ReturnsBadRequestWithMultipleErrors()
        {
            //Arrange
            UserDto payload = null;

            //Act
            var response = await _httpClient.PostAsync("/users/create", TestHelper.BuildJsonContent(payload));
            var responseObj = await TestHelper.TryToReadResponseAsync<ErrorResponseDto>(response);

            //Asserts
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            responseObj.Errors.Count.Should().BeGreaterThan(1);
        }

        [Fact]
        public async Task Create_AllDataIsCorrect_ReturnsOk()
        {
            //Arrange
            var payload = new UserDto
            {
                Name = "German Bertolini",
                Address = "Buenos Aires, Argentina",
                Email = "german.bertolini@gmail.com",
                Money = 100,
                Phone = "1234-1234",
                UserType = UserType.Normal
            };

            //Act
            var response = await _httpClient.PostAsync("/users/create", TestHelper.BuildJsonContent(payload));

            //Asserts
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}