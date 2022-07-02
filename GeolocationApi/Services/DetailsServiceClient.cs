using GeolocationApi.Contracts;
using GeolocationApi.Dto;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace GeolocationApi.Services;

public class DetailsServiceClient : IDetailsServiceClient
{
    private readonly HttpClient httpClient;
    private readonly IConfiguration configuration;

    public DetailsServiceClient(HttpClient httpClient, IConfiguration configuration)
    {
        this.httpClient = httpClient;
        this.configuration = configuration;
        InitializeClient();
    }

    public async Task<IpDetails> GetDetailsAsync(string ip)
    {
        using var response = await httpClient.GetAsync($"{ip}?access_key={configuration["IpStack:AccessKey"]}", HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();
        var stream = await response.Content.ReadAsStreamAsync();
        using var streamReader = new StreamReader(stream);
        using var jsonReader = new JsonTextReader(streamReader);
        var serializer = new JsonSerializer();
        return serializer.Deserialize<IpDetails>(jsonReader);
    }

    private void InitializeClient()
    {
        httpClient.BaseAddress = new Uri(configuration["IpStack:Endpoint"]);
        httpClient.Timeout = new TimeSpan(0, 0, 30);
        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
}