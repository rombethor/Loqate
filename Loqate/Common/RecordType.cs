using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Loqate.Common
{
    [JsonConverter(typeof(JsonStringEnumConverter<RecordType>))]
    public enum RecordType
    {
        [EnumMember(Value = "Address")]
        Address,
        [EnumMember(Value = "Container")]
        Container,
        [EnumMember(Value = "Postcode")]
        Postcode,
        [EnumMember(Value = "Locality")]
        Locality,
        [EnumMember(Value = "BuildingName")]
        BuildingName,
        [EnumMember(Value = "Street")]
        Street
    }
}
