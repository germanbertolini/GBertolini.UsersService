using GBertolini.UsersService.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GBertolini.UsersService.Models.Dto
{
    public class UserDto
    {
        [Required(ErrorMessage = "'name' value is required.")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "'email' value is required.")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "'address' value is required.")]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "'phone' value is required.")]
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("user_type")]
        public UserType UserType { get; set; }

        [JsonPropertyName("money")]
        public decimal Money { get; set; }
    }
}
