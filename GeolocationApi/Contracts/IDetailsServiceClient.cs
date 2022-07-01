using GeolocationApi.Dto;

namespace GeolocationApi.Contracts;

public interface IDetailsServiceClient
{
    Task<IpDetails> GetDetailsAsync(string ip);
}