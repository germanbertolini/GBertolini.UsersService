using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GBertolini.UsersService.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserType
    {
        [EnumMember(Value = "normal")]
        Normal,

        [EnumMember(Value = "super_user")]
        SuperUser,

        [EnumMember(Value = "premium")]
        Premium
    }
}
