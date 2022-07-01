using Newtonsoft.Json;

namespace GeolocationApi.Dto;

public class Connection
{
    [JsonProperty("asn")]
    public int? Asn { get; set; }

    [JsonProperty("isp")]
    public string Isp { get; set; }
}