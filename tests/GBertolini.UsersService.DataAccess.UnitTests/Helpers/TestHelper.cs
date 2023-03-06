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
        /// Builds a mocked UsersDbContext instance for tests
        /// </summary>
        public static UsersDbContext BuildMockedUsersDbContext()
        {
            var data = new List<User>();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            mockSet.Setup(m => m.Add(It.IsAny<User>()))
                   .Returns<User>((p) => { data.Add(p); return It.IsAny<EntityEntry<User>>(); });

            var mockContext = new Mock<UsersDbContext>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);

            return mockContext.Object;
        }

        /// <summary>
        /// Returns the predicate to find users by name, address, email and phone
        /// </summary>
        public static Expression<Func<User, bool>> PredicateToMatchUser(User user)
            => (u) => u.Name.Equals(user.Name)
                        && u.Address.Equals(user.Address)
                        && u.Email.Equals(user.Email)
                        && u.Phone.Equals(user.Phone);
    }
}
