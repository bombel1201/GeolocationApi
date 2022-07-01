using System.Collections.Concurrent;
using GeolocationApi.Contracts;

namespace GeolocationApi.Data.Repository
{
    public class IpDetailsRepositoryInMemory : IIpDetailsRepository
    {
        private readonly ConcurrentDictionary<string, string> ipsWithDetails = new();

        public void Create(string ip, string details)
        {
            if (ip == null)
            {
                throw new ArgumentNullException(nameof(ip));
            }

            ipsWithDetails[ip] = details;
        }

        public void Update(string ip, string details)
        {
            if (ip == null)
            {
                throw new ArgumentNullException(nameof(ip));
            }

            ipsWithDetails[ip] = details;
        }

        public void Delete(string ip)
        {
            if (ip == null)
            {
                throw new ArgumentNullException(nameof(ip));
            }

            if (!ipsWithDetails.ContainsKey(ip))
            {
                return;
            }

            ipsWithDetails.Remove(ip, out var details);
        }

        public async Task<IEnumerable<string>> GetDetailsAsync()
        {
            var result = ipsWithDetails.Values.ToList();
            return await Task.FromResult(result);
        }

        public async Task<string> GetDetailsAsync(string ip)
        {
            if (ip == null)
            {
                throw new ArgumentNullException(nameof(ip));
            }

            if (!ipsWithDetails.ContainsKey(ip))
            {
                return await Task.FromResult<string>(null);
            }

            if (!ipsWithDetails.TryGetValue(ip, out var details))
            {
                return await Task.FromResult<string>(null);
            }

            return details;
        }

        public Task SaveAsync()
        {
            return Task.CompletedTask;
        }
    }
}