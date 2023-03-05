using FluentAssertions;
using GBertolini.UsersService.Models.Sanitizers;

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
