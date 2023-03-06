using GBertolini.UsersService.API.Filters;
using GBertolini.UsersService.API.Interceptors;
using GBertolini.UsersService.Business.Users.Implementation;
using GBertolini.UsersService.DataAccess;
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
        /// Dependency Injection: Setup UsersDbContext
        /// </summary>
        public static void AddUsersDbContext(this IServiceCollection services)
        {
            services.AddSingleton<UsersDbContext>();
        }

        /// <summary>
        /// Dependency Injection: Setup Users services
        /// </summary>
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

        /// <summary>
        /// Creates Database structure if it does not already exist
        /// </summary>
        public static void EnsureDatabaseTables(this IApplicationBuilder builder)
        {
            var db = (UsersDbContext)builder.ApplicationServices.GetService(typeof(UsersDbContext));
            db.Database.EnsureCreatedAsync().Wait();
        }
    }
}
