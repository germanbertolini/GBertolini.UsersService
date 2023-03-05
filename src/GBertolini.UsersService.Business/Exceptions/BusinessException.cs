using System.Net;

namespace GBertolini.UsersService.Business.Exceptions
{
    public class BusinessException : Exception
    {
        private HttpStatusCode _statusCode;
        public HttpStatusCode GetStatusCode() => _statusCode;

        public BusinessException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            _statusCode = statusCode;
        }

        public BusinessException(HttpStatusCode statusCode, string message, Exception inner)
            : base(message, inner)
        {
            _statusCode = statusCode;
        }
    }
}
