using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GBertolini.UsersService.Models.Dto.Response
{
    public class ResponseWithErrorsDto
    {
        [JsonPropertyName("success")]
        public bool Success { get; } = false;

        [JsonPropertyName("errors")]
        public List<string> Errors { get; }

        public ResponseWithErrorsDto()
                    => Errors = new List<string>();

        public ResponseWithErrorsDto(string error)
                    => Errors = new List<string> { error };

        public ResponseWithErrorsDto(List<string> errors)
                    => Errors = errors;
    }
}
