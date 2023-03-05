using GBertolini.UsersService.Models.Attributes;
using GBertolini.UsersService.Models.Models.Implementations;
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
        [EnumMember(Value = "Normal")]
        [Factory(CreateInstanceOf: typeof(NormalUser))]
        Normal,

        [EnumMember(Value = "SuperUser")]
        [Factory(CreateInstanceOf: typeof(SuperUser))]
        SuperUser,

        [EnumMember(Value = "Premium")]
        [Factory(CreateInstanceOf: typeof(PremiumUser))]
        Premium
    }
}
