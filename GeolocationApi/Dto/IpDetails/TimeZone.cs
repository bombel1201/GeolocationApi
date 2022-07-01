using System.Text.Json.Serialization;

namespace GeolocationApi.Dto;

public record TimeZone(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("current_time")] DateTime CurrentTime,
    [property: JsonPropertyName("gmt_offset")] int GmtOffset,
    [property: JsonPropertyName("code")] string Code,
    [property: JsonPropertyName("is_daylight_saving")] bool IsDaylightSaving
);