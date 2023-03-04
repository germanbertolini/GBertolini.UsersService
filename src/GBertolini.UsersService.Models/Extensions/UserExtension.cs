using GBertolini.UsersService.Models.Attributes;
using GBertolini.UsersService.Models.Enums;
using GBertolini.UsersService.Models.Models.Interfaces;

namespace GBertolini.UsersService.Models.Extensions
{
    public static class UserExtension
    {
        /// <summary>
        /// Retrieves the Enum value for this User class type
        /// </summary>
        public static UserType ToEnum(this IUser user)
                => typeof(UserType)
                        .GetFields()
                        .Where(field => ((FactoryAttribute?)Attribute.GetCustomAttribute(field, typeof(FactoryAttribute)))?.CreateInstanceOf == user.GetType())
                        .Select(field => (UserType)Enum.Parse(typeof(UserType), field.Name))
                        .FirstOrDefault();

        /// <summary>
        /// Returns the User class type for the indicated enum option
        /// </summary>
        public static Type GetUserClassType(this UserType userType)
        {
            var member = typeof(UserType).GetField(Enum.GetName(userType));
            return ((FactoryAttribute?)Attribute.GetCustomAttribute(member, typeof(FactoryAttribute)))?.CreateInstanceOf;
        }
    }
}
