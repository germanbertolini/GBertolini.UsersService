using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using GBertolini.UsersService.Models.Dto.Response;

namespace GBertolini.UsersService.API.Filters
{
    public class ValidateInputModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errorList = context.ModelState.Values
                                    .Where(v => v.Errors.Count > 0)
                                    .Select(err => err.Errors.First().ErrorMessage)
                                    .ToList();

                context.Result = new JsonResult(new ResponseWithErrorsDto(errorList)) { StatusCode = StatusCodes.Status400BadRequest };
            }
        }
    }
}
