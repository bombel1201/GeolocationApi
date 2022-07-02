using GeolocationApi.Contracts;
using GeolocationApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeolocationApi.Data.Repository;

public class IpDetailsSqlLiteRepository : IIpDetailsRepository
{
    private readonly GeolocationDbContext dbContext;

    public IpDetailsSqlLiteRepository(GeolocationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Create(string ip, string details)
    {
        var entity = MapToEntity(ip, details);
        dbContext.Geolocations.Add(entity);
    }

    public void Update(string ip, string details)
    {
        var entity = MapToEntity(ip, details);
        dbContext.Geolocations.Update(entity);
    }

    public void Delete(string ip)
    {
        var entity = dbContext.Geolocations.SingleOrDefault(x => x.Ip == ip);
        if (entity == null)
        {
            return;
        }

        dbContext.Geolocations.Remove(entity);
    }

    public async Task<string> GetDetailsAsync(string ip)
    {
        return await dbContext.Geolocations.Where(x => x.Ip == ip).Select(x => x.Payload).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<string>> GetDetailsAsync()
    {
        return await dbContext.Geolocations.Select(x => x.Payload).ToListAsync();
    }

    public async Task SaveAsync()
    {
        await dbContext.SaveChangesAsync();
    }

    private static Geolocation MapToEntity(string ip, string details)
    {
        var entity = new Geolocation
        {
            Ip = ip,
            Payload = details
        };
        return entity;
    }
}