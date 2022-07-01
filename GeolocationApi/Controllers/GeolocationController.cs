using Microsoft.AspNetCore.Mvc;
using GeolocationApi.Contracts;
using GeolocationApi.Dto;

namespace GeolocationApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GeolocationController : ControllerBase
{
    private readonly ILogger<GeolocationController> logger;
    private readonly IIpDetailsRepository ipDetailsRepository;
    private readonly IDetailsServiceClient detailsServiceClient;

    public GeolocationController(ILogger<GeolocationController> logger,
        IIpDetailsRepository ipDetailsRepository,
        IDetailsServiceClient detailsServiceClient)
    {
        this.logger = logger;
        this.ipDetailsRepository = ipDetailsRepository;
        this.detailsServiceClient = detailsServiceClient;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<IpDetails>>> Get()
    {
        var details = await ipDetailsRepository.GetDetailsAsync();
        return Ok(details);
    }

    [HttpPost("{ip}")]
    public async Task<ActionResult<IpDetails>> Create(string ip)
    {
        if (string.IsNullOrWhiteSpace(ip))
        {
            logger.LogError("Ip sent from client is null or empty.");
            return BadRequest("Empty ip passed.");
        }

        var details = await detailsServiceClient.GetDetailsAsync(ip);
        if (details == null)
        {
            logger.LogError($"Cannot download details for ip: {ip}.");
            return StatusCode(StatusCodes.Status503ServiceUnavailable,
                $"Cannot download details for ip: {ip}.");
        }

        ipDetailsRepository.Create(ip, details.ToJson());

        var dto = await ipDetailsRepository.GetDetailsAsync(ip);
        if (string.IsNullOrWhiteSpace(dto))
        {
            logger.LogError("Writing to database failed.");
            return NotFound();
        }

        return Ok(dto.FromJson<IpDetails>());
    }

    [HttpPut]
    public async Task<ActionResult<IpDetails>> Update(IpDetails newDetails)
    {
        if (string.IsNullOrWhiteSpace(newDetails?.Ip))
        {
            logger.LogError("Invalid details sent from client.");
            return BadRequest("Send object does not contain Ip.");
        }

        var dto = await ipDetailsRepository.GetDetailsAsync(newDetails.Ip);
        if (string.IsNullOrWhiteSpace(dto))
        {
            return NotFound($"Ip details for {newDetails.Ip} was not found.");
        }

        ipDetailsRepository.Update(newDetails.Ip, newDetails.ToJson());
        await ipDetailsRepository.SaveAsync();

        dto = await ipDetailsRepository.GetDetailsAsync(newDetails.Ip);
        if (string.IsNullOrWhiteSpace(dto))
        {
            logger.LogError("Writing to database failed.");
            return NotFound();
        }

        return Ok(dto.FromJson<IpDetails>());
    }

    [HttpDelete("{ip}")]
    public async Task<ActionResult<IpDetails>> Delete(string ip)
    {
        if (string.IsNullOrWhiteSpace(ip))
        {
            logger.LogError("Ip sent from client is null or empty.");
            return BadRequest("Empty ip passed.");
        }

        var dto = await ipDetailsRepository.GetDetailsAsync(ip);
        if (string.IsNullOrWhiteSpace(dto))
        {
            logger.LogError("Reading from database failed.");
            return NotFound("Details not found");
        }

        ipDetailsRepository.Delete(ip);
        await ipDetailsRepository.SaveAsync();

        return Ok(dto.FromJson<IpDetails>());
    }
}