using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Loqate.Retrieve
{
    public class RetrieveResponse
    {
        [JsonPropertyName("Items")]
        public RetrieveResponseItem[] Items { get; set; } = [];
    }
}
