using GBertolini.UsersService.API.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GBertolini.UsersService.API.Extensions
{
    public static class StartupExtensions
    {
        public static void AddValidateInputModelFilter(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddScoped<ValidateInputModelAttribute>();
        }
    }
}
