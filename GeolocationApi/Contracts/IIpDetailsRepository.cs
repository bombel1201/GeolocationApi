namespace GeolocationApi.Contracts;

public interface IIpDetailsRepository
{
    void Create(string ip, string details);
    void Update(string ip, string details);
    void Delete(string ip);
    Task<string> GetDetailsAsync(string ip);
    Task<IEnumerable<string>> GetDetailsAsync();
    Task SaveAsync();
}