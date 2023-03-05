using GBertolini.UsersService.API.Filters;
using GBertolini.UsersService.API.Interceptors;
using GBertolini.UsersService.Business.Users.Implementation;
using GBertolini.UsersService.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GBertolini.UsersService.API.Extensions
{
    /// <summary>
    /// Extension methods for setting up custom services
    /// </summary>
    public static class StartupExtensions
    {
        /// <summary>
        /// Dependency Injection: Setup Users services
        /// </summary>
        /// <param name="services"></param>
        public static void AddUsersServices(this IServiceCollection services)
        {
            services.AddScoped<UsersRepository>();
            services.AddScoped<UsersBusiness>();
        }

        /// <summary>
        /// Setup ValidateInputModelFilter to be used as model validator in transactions
        /// </summary>
        public static void AddValidateInputModelFilter(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddScoped<ValidateInputModelAttribute>();
        }

        /// <summary>
        /// Setup middleware to handle Exceptions
        /// </summary>
        public static void UseInterceptorErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
