using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Loqate.Find
{
    public class FindResponse
    {
        [JsonPropertyName("Items")]
        public FindItem[] Items { get; set; } = [];
    }
}
