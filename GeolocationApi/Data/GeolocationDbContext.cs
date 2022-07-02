using GeolocationApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeolocationApi.Data
{
    public class GeolocationDbContext : DbContext
    {
        private readonly string databasePath;
        public DbSet<Geolocation> Geolocations { get; set; }

        public GeolocationDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            databasePath = Path.Join(path, "geolocationapi.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={databasePath}");
        }
    }
}