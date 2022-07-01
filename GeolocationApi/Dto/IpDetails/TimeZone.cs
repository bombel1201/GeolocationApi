using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace GeolocationApi.Dto;

public class TimeZone
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("current_time")]
    public DateTime? CurrentTime { get; set; }

    [JsonProperty("gmt_offset")]
    public int GmtOffset { get; set; }

    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("is_daylight_saving")]
    public bool? IsDaylightSaving { get; set; }
}
