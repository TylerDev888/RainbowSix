using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RainbowSix.Common.Models
{
    public class GraphQLRequest<TVariables>
    {
        [JsonPropertyName("operationName")]
        public string OperationName { get; set; } = string.Empty;

        [JsonPropertyName("variables")]
        public TVariables? Variables { get; set; }

        [JsonPropertyName("query")]
        public string Query { get; set; } = string.Empty;
    }
}
