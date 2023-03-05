using FluentAssertions;
using GBertolini.UsersService.Models.Sanitizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBertolini.UsersService.API.Models.UnitTests.Sanitizers
{
    public class StringSanitizerTest
    {
        [Fact]
        public void Sanitizer_ReceiveStringWithWhitespaces_ReturnsTrimedString()
        {
            //Arrange
            var value = "    German Bertolini ";

            //Act
            var result = StringSanitizer.Sanitize(value);

            //Asserts
            result.Should().Be("German Bertolini");
        }
    }
}
