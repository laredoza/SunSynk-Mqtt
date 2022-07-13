using Microsoft.AspNetCore.Mvc;
using Api.Services;
using Api.Authentication.Plants.Responses;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PlantsController : ControllerBase
{
    private readonly ILogger<PlantsController> _logger;
    private readonly ISunSynkService _sunSynkService;

    public PlantsController(
        ILogger<PlantsController> logger!!,
        ISunSynkService sunSynkService!!
        )
    {
        _logger = logger;
        this._sunSynkService = sunSynkService;
    }

    [HttpGet(Name = "[action]/GetPlants/{page}/{limit}/{name}/{status}")]
    public async Task<ActionResult<PlantsResponse>> GetPlants(int page = 1, int limit = 10, string? name = "", string? status = "")
    {
        return Ok(await this._sunSynkService.GetPlants(page, limit, name, status));
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
