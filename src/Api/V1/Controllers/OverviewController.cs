using Microsoft.AspNetCore.Mvc;
using Api.Services;
using Api.Authentication.Overview.Responses.Energy;
using Api.Authentication.Overview.Responses.Production;
using Api.Authentication.Overview.Responses.Flows;
using Api.Authentication.Overview.Responses.GenerationPurpose;
using Api.Authentication.Overview.Responses.PlantInformation;

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
	public async Task<ActionResult<ProductionResponse>> GetProduction(long plantId)
	{
		return Ok(await this._sunSynkService.GetOverviewProduction(plantId));
	}

	[HttpGet("Weather/{lonlat}/{language}/{date}")]
	public async Task<ActionResult<WeatherResponse>> GetOverviewWeather(string lonlat = "-25.706774,28.259229", string language = "en", DateTimeOffset? date = null) 
	{
		return Ok(await this._sunSynkService.GetOverviewWeather(lonlat, language, date));
	}

	[HttpGet("PowerFlow/{plantId}/{date}")]
	public async Task<ActionResult<FlowResponse>> GetOverviewEnergyFlow(long plantId, DateTimeOffset? date)
	{
		return Ok(await this._sunSynkService.GetOverviewEnergyFlow(plantId, date));
	}

	//Plant Info

	// Status

	[HttpGet("GenerationPurpose/{plantId}")]
	public async Task<ActionResult<GenerationPurposeResponse>> GetOverviewGenerationPurpose(long plantId)
	{
		return Ok(await this._sunSynkService.GetOverviewGenerationPurpose(plantId));
	}

	[HttpGet("AbnormalStatistics/{plantId}")]
	public async Task<ActionResult<EnergyResponse>> GetAbnormalStatistics(long plantId)
	{
		return Ok(await this._sunSynkService.GetAbnormalStatistics(plantId));
	}

	[HttpGet("EnergyGeneration/{plantId}/{date}/{language}")]
	public async Task<ActionResult<EnergyResponse>> GetOverviewEnergy(long plantId, DateTimeOffset? date, string language = "en")
	{
		return Ok(await this._sunSynkService.GetOverviewEnergy(plantId, date, language));
	}

	[HttpGet("UserInfo/{language}")]
	public async Task<ActionResult<EnergyResponse>> GetUserInfo(string language = "en")
	{
		return Ok(await this._sunSynkService.GetUserInfo(language));
	}

	[HttpGet("PlantInfo/{plantId}/{language}")]
	public async Task<ActionResult<PlantInformationResponse>> GetOverviewPlantInfo(long plantId, string language = "en")
	{
		return Ok(await this._sunSynkService.GetOverviewPlantInfo(plantId, language));
	}
}
