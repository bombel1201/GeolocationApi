using Newtonsoft.Json;

namespace GeolocationApi.Dto;

public class IpDetails
{
    [JsonProperty("ip")]
    public string Ip { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("continent_code")]
    public string ContinentCode { get; set; }

    [JsonProperty("continent_name")]
    public string ContinentName { get; set; }

    [JsonProperty("country_code")]
    public string CountryCode { get; set; }

    [JsonProperty("country_name")]
    public string CountryName { get; set; }

    [JsonProperty("region_code")]
    public string RegionCode { get; set; }

    [JsonProperty("region_name")]
    public string RegionName { get; set; }

    [JsonProperty("city")]
    public string City { get; set; }

    [JsonProperty("zip")]
    public string Zip { get; set; }

    [JsonProperty("latitude")]
    public double? Latitude { get; set; }

    [JsonProperty("longitude")]
    public double? Longitude { get; set; }

    [JsonProperty("location")]
    public Location Location { get; set; }

    [JsonProperty("time_zone")]
    public TimeZone TimeZone { get; set; }

    [JsonProperty("currency")]
    public Currency Currency { get; set; }

    [JsonProperty("connection")]
    public Connection Connection { get; set; }
}