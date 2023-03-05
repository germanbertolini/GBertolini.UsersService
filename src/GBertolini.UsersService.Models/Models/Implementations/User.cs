using GBertolini.UsersService.Models.Enums;
using GBertolini.UsersService.Models.Models.Interfaces;

namespace GBertolini.UsersService.Models.Models.Implementations
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public decimal Money { get; set; }
        public UserType UserType { get; set; }

        public virtual void ApplyGift()
            => throw new NotImplementedException();
    }
}
