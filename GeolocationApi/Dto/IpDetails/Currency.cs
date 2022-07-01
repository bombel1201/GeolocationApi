using System.Text.Json.Serialization;

namespace GeolocationApi.Dto;

public record Currency(
    [property: JsonPropertyName("code")] string Code,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("plural")] string Plural,
    [property: JsonPropertyName("symbol")] string Symbol,
    [property: JsonPropertyName("symbol_native")] string SymbolNative
);