using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OverviewController : ControllerBase
{
    private readonly ILogger<OverviewController> _logger;

    public OverviewController(ILogger<OverviewController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetCurrentStatus")]
    public string GetCurrentStatus()
    {
        throw new NotImplementedException();
    }

    // [HttpGet(Name = "GetPowerFlow")]
    // public string GetPowerFlow()
    // {
    //     throw new NotImplementedException();
    // }

    // [HttpGet(Name = "GetStatus")]
    // public string GetStatus()
    // {
    //     throw new NotImplementedException();
    // }

    // [HttpGet(Name = "GetGenerationPurpose")]
    // public string GetGenerationPurpose()
    // {
    //     throw new NotImplementedException();
    // }
    // [HttpGet(Name = "GetAbnormalStatistics")]
    // public string GetAbnormalStatistics()
    // {
    //     throw new NotImplementedException();
    // }
    // [HttpGet(Name = "GetEnergyGeneration")]
    // public string GetEnergyGeneration()
    // {
    //     throw new NotImplementedException();
    // }
}
