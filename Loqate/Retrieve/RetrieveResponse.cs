using Loqate.Common;
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
        [JsonPropertyName("Id"), JsonRequired]
        public string Id { get; set; }

        [JsonPropertyName("DomesticId")]
        public string? DomesticId { get; set; }

        [JsonPropertyName("Language")]
        public string? Language { get; set; }

        [JsonPropertyName("LanguageAlternatives")]
        public string? LanguageAlternatives { get; set; }

        [JsonPropertyName("Department")]
        public string? Department { get; set; }

        [JsonPropertyName("Company")]
        public string? Company { get; set; }

        [JsonPropertyName("SubBuilding")]
        public string? SubBuilding { get; set; }

        [JsonPropertyName("BuildingNumber")]
        public string? BuildingNumber { get; set; }

        [JsonPropertyName("BuildingName")]
        public string? BuildingName { get; set; }

        [JsonPropertyName("SecondaryStreet")]
        public string? SecondaryStreet { get; set; }

        [JsonPropertyName("Street")]
        public string? Street { get; set; }

        [JsonPropertyName("Block")]
        public string? Block { get; set; }

        [JsonPropertyName("Neighbourhood")]
        public string? Neighbourhood { get; set; }

        [JsonPropertyName("District")]
        public string? District { get; set; }

        [JsonPropertyName("City")]
        public string? City { get; set; }

        [JsonPropertyName("Line1")]
        public string? Line1 { get; set; }

        [JsonPropertyName("Line2")]
        public string? Line2 { get; set; }

        [JsonPropertyName("Line3")]
        public string? Line3 { get; set; }

        [JsonPropertyName("Line4")]
        public string? Line4 { get; set; }

        [JsonPropertyName("Line5")]
        public string? Line5 { get; set; }

        [JsonPropertyName("AdminAreaName")]
        public string? AdminAreaName { get; set; }

        [JsonPropertyName("AdminAreaCode")]
        public string? AdminAreaCode { get; set; }

        [JsonPropertyName("Province")]
        public string? Province { get; set; }
        [JsonPropertyName("ProvinceName")]
        public string? ProvinceName { get; set; }

        [JsonPropertyName("ProvinceCode")]
        public string? ProvinceCode { get; set; }

        [JsonPropertyName("PostalCode")]
        public string? PostalCode { get; set; }

        [JsonPropertyName("CountryName")]
        public string? CountryName { get; set; }

        [JsonPropertyName("CountryIso2")]
        public string? CountryIso2 { get; set; }

        [JsonPropertyName("CountryIso3")]
        public string? CountryIso3 { get; set; }

        [JsonPropertyName("CountryIsoNumber")]
        public string? CountryIsoNumber { get; set; }

        [JsonPropertyName("SortingNumber1")]
        public string? SortingNumber1 { get; set; }

        [JsonPropertyName("SortingNumber2")]
        public string? SortingNumber2 { get; set; }

        [JsonPropertyName("Barcode")]
        public string? Barcode { get; set; }

        [JsonPropertyName("POBoxNumber")]
        public string? POBoxNumber { get; set; }

        [JsonPropertyName("Label")]
        public string? Label { get; set; }

        [JsonPropertyName("Type")]
        public RecordType Type { get; set; }

        [JsonPropertyName("DataLevel")]
        public string? DataLevel { get; set; }

        [JsonPropertyName("Field1")]
        public string? Field1 { get; set; }
        
        [JsonPropertyName("Field2")]
        public string? Field2 { get; set; }
        


    }
}
