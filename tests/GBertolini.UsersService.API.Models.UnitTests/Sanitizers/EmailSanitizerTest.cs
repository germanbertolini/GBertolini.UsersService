using FluentAssertions;
using GBertolini.UsersService.Models.Enums;
using GBertolini.UsersService.Models.Factories;
using GBertolini.UsersService.Models.Models.Implementation;
using GBertolini.UsersService.Models.Sanitizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBertolini.UsersService.API.Models.UnitTests.Sanitizers
{
    public class EmailSanitizerTest
    {
        [Fact]
        public void Sanitizer_ReceiveNormalizedAddress_ReturnsSameAddress()
        {
            //Arrange
            var email = "germanbertolini@gmail.com";

            //Act
            var result = EmailSanitizer.Sanitize(email);

            //Asserts
            result.Should().Be("germanbertolini@gmail.com");
        }

        [Fact]
        public void Sanitizer_ReceiveAnormalAddress_ReturnsNormalizedAddress()
        {
            //Arrange
            var email = "german.bertolini+German Bertolini@subdomain.gmail.com";

            //Act
            var result = EmailSanitizer.Sanitize(email);

            //Asserts
            result.Should().Be("germanbertolini@subdomain.gmail.com");
        }
    }
}
