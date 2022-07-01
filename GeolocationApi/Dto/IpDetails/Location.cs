using System.Text.Json.Serialization;

namespace GeolocationApi.Dto;

public record Location(
    [property: JsonPropertyName("geoname_id")] int GeonameId,
    [property: JsonPropertyName("capital")] string Capital,
    [property: JsonPropertyName("languages")] IReadOnlyList<Language> Languages,
    [property: JsonPropertyName("country_flag")] string CountryFlag,
    [property: JsonPropertyName("country_flag_emoji")] string CountryFlagEmoji,
    [property: JsonPropertyName("country_flag_emoji_unicode")] string CountryFlagEmojiUnicode,
    [property: JsonPropertyName("calling_code")] string CallingCode,
    [property: JsonPropertyName("is_eu")] bool IsEu
);