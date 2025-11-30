using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RainbowSix.Common.Models.Response.Error
{
    public class ErrorResponse
    {
        [JsonPropertyName("errors")]
        public List<Error>? Errors { get; set; }

        [JsonPropertyName("data")]
        public object? Data { get; set; }
    }
}
