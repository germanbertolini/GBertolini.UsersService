using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GBertolini.UsersService.Models.Dto.Response
{
    public class ResponseDto
    {
        [JsonPropertyName("success")]
        public bool Success { get; } = true;
    }

    public class ResponseDto<TResponse> : ResponseDto
    {
        [JsonPropertyName("data")]
        public TResponse Data { get; }

        public ResponseDto(TResponse content)
                    => Data = content;
    }
}
