using GBertolini.UsersService.Business.Exceptions;
using GBertolini.UsersService.Models.Dto.Response;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace GBertolini.UsersService.API.Interceptors
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate requestDelegate, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = requestDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var startedTime = DateTime.Now;
            _logger.LogInformation($"Transaction started at {startedTime}");

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }

            var finishedTime = DateTime.Now;
            _logger.LogInformation($"Transaction finished at {finishedTime} after {(finishedTime - startedTime).TotalMilliseconds} miliseconds.");
        }

        /// <summary>
        /// Handle the exception occurred
        /// </summary>
        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = StatusCodes.Status500InternalServerError;
            var response = "An internal error has occurred.";

            if (ex is BusinessException)
            {
                statusCode = (int)((BusinessException)ex).GetStatusCode();
                response = ex.Message;
            }
            else
            {
                _logger.LogError(ex, $"Transaction finished on http {statusCode}. Context: {context}");
            }

            await WriteExceptionAsync(context, response, statusCode);
        }

        /// <summary>
        /// Overwrite response with exception message
        /// </summary>
        private async Task WriteExceptionAsync(HttpContext context, string responseMessage, int statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ResponseWithErrorsDto(responseMessage)));
        }
    }
}
