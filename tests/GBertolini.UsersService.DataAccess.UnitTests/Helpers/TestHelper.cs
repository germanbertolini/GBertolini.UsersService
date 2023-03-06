using GBertolini.UsersService.DataAccess.Repositories;
using GBertolini.UsersService.Models.Models.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using System.Linq.Expressions;

namespace GBertolini.UsersService.DataAccess.UnitTests.Helpers
{
    public static class TestHelper
    {
        /// <summary>
        /// Returns the predicate to find users by name, address, email and phone
        /// </summary>
        public static Expression<Func<User, bool>> PredicateToMatchUser(User user)
            => (u) => u.Name.Equals(user.Name)
                        && u.Address.Equals(user.Address)
                        && u.Email.Equals(user.Email)
                        && u.Phone.Equals(user.Phone);

        /// <summary>
        /// Prepares the environment
        /// </summary>
        public static void PrepareEnvironment()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "UnitTesting");
        }
    }
}
