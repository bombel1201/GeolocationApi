using System.Text.Json.Serialization;

namespace GeolocationApi.Dto;

public record Connection(
    [property: JsonPropertyName("asn")] int Asn,
    [property: JsonPropertyName("isp")] string Isp
);