using System.Text.Json.Serialization;

namespace GeolocationApi.Dto;

public record Language(
    [property: JsonPropertyName("code")] string Code,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("native")] string Native
);