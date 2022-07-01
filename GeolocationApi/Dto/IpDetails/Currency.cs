using Newtonsoft.Json;

namespace GeolocationApi.Dto;

public class Currency
{
    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("plural")]
    public string Plural { get; set; }

    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("symbol_native")]
    public string SymbolNative { get; set; }
}