using GBertolini.UsersService.Models.Models.Implementations;
using Microsoft.EntityFrameworkCore;

namespace GBertolini.UsersService.DataAccess.Repositories
{
    public class UsersRepository
    {
        private readonly UsersDbContext _db;

        public UsersRepository(UsersDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Creates the User into Database
        /// </summary>
        public async Task CreateAsync(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Search the User into Database by Name and Address
        /// </summary>
        public Task<User?> FindByNameAndAddressAsync(string name, string address)
            => _db.Users.FirstOrDefaultAsync(user => user.Name.Equals(name) &&
                                                     user.Address.Equals(address));

        /// <summary>
        /// Search the User into Database by Email or Phone
        /// </summary>
        public Task<User?> FindByEmailOrPhoneAsync(string name, string phone)
            => _db.Users.FirstOrDefaultAsync(user => user.Email.Equals(name) ||
                                                     user.Phone.Equals(phone));
    }
}