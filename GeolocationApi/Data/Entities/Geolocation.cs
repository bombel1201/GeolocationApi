using System.ComponentModel.DataAnnotations;

namespace GeolocationApi.Data.Entities;

public class Geolocation
{
    [Key]
    public string Ip { get; set; }

    [Required]
    public string Payload { get; set; }
}