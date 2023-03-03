using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GBertolini.UsersService.Models.Dto
{
    public class ErrorResponseDto
    {
        [JsonPropertyName("errors")]
        public List<string> Errors { get;  set; }

        public ErrorResponseDto(string error)
        {
            Errors = new List<string> { error };
        }

        public ErrorResponseDto(List<string> errors)
        {
            Errors = errors;
        }
    }
}
