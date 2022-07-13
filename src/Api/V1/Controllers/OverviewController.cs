using Microsoft.AspNetCore.Mvc;
using Api.Services;
using Api.Authentication.Overview.Responses.Energy;
using Api.Authentication.Overview.Responses.Production;
using Api.Authentication.Overview.Responses.Flows;
using Api.Authentication.Plants.Responses;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OverviewController : ControllerBase
{
	private readonly ILogger<OverviewController> _logger;
	private readonly ISunSynkService _sunSynkService;

	public OverviewController(
	    ILogger<OverviewController> logger!!,
	    ISunSynkService sunSynkService!!
	    )
	{
		_logger = logger;
		this._sunSynkService = sunSynkService;
	}

	[HttpGet("CurrentStatus/{plantId}")]
	public async Task<ActionResult<ProductionResponse>> GetOverviewProduction(long plantId)
	{
		return Ok(await this._sunSynkService.GetOverviewProduction(plantId));
	}

	//Weather Info

	[HttpGet("PowerFlow/{plantId}")]
	public async Task<ActionResult<FlowResponse>> GetOverviewEnergyFlow(long plantId, DateTimeOffset? dateTime)
	{
		return Ok(await this._sunSynkService.GetOverviewEnergyFlow(plantId, dateTime));
	}

	//Plant Info

	// Status

	[HttpGet("GenerationPurpose/{plantId}")]
	public async Task<ActionResult<GenerationPurposeResponse>> GetOverviewGenerationPurpose(long plantId)
	{
		return Ok(await this._sunSynkService.GetOverviewGenerationPurpose(plantId));
	}

    // Abnormal Statistics

	[HttpGet("EnergyGeneration/{plantId}/{date}/{language}")]
	public async Task<ActionResult<EnergyResponse>> GetOverviewEnergy(long plantId, DateTimeOffset? date, string language = "en")
	{
		return Ok(await this._sunSynkService.GetOverviewEnergy(plantId, date, language));
	}
}
