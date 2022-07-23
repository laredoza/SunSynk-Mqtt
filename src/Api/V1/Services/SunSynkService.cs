namespace Api.Services
{
	#region Usings

	using System;
	using System.Text.Json;
	using Api.Authentication.Overview.Responses.AbnormalStatistics;
	using Api.Authentication.Overview.Responses.Energy;
	using Api.Authentication.Overview.Responses.Flows;
	using Api.Authentication.Overview.Responses.GenerationPurpose;
	using Api.Authentication.Overview.Responses.PlantInformation;
	using Api.Authentication.Overview.Responses.Plants;
	using Api.Authentication.Overview.Responses.Production;
	using Api.Authentication.Overview.Responses.UserInfo;
	using Api.Configuration;
	using Microsoft.Extensions.Options;

	public interface ISunSynkService
	{
		Task<PlantsResponse> GetPlants(int page = 1, int limit = 10, string name = "", string status = "");
		Task<EnergyResponse> GetOverviewEnergy(long plantId, DateTimeOffset? date, string language = "en");
		Task<ProductionResponse> GetOverviewProduction(long plantId);
		Task<FlowResponse> GetOverviewEnergyFlow(long plantId, DateTimeOffset? date);
		Task<WeatherResponse> GetOverviewWeather(string lonlat = "-25.706774,28.259229", string language = "en", DateTimeOffset? date = null);
		Task<GenerationPurposeResponse> GetOverviewGenerationPurpose(long plantId);
		Task<AbnormalStatisticsResponse> GetAbnormalStatistics(long plantId);
		Task<UserInfoResponse> GetUserInfo(string language = "en");
		Task<PlantInformationResponse> GetOverviewPlantInfo(long plantId, string language = "en");
	}

	#endregion

	/// <summary>
	///     The SunSynkService.
	/// </summary>
	public class SunSynkService : ISunSynkService
	{
		private readonly HttpClient _httpClient;
		private readonly SunSynk _settings;
		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="SunSynkService"/> class.
		/// </summary>
		public SunSynkService(HttpClient httpClient!!, IOptions<SunSynk> settings!!)
		{
			this._httpClient = httpClient;
			this._settings = settings.Value;
		}

		#endregion

		#region Public Properties


		#endregion

		#region Public Methods And Operators

		public async Task<PlantsResponse> GetPlants(int page = 1, int limit = 10, string name = "", string status = "")
		{
			var response = await this._httpClient.GetAsync($"{this._settings.Url}/v1/plants?page={page}&limit={limit}0&name={name}&status={status}");
			if (response != null && response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				if (!string.IsNullOrEmpty(responseString))
				{
					return JsonSerializer.Deserialize<PlantsResponse>(responseString);
				}
				else
				{
					throw new Exception("Invalid plants response");
				}
			}
			else
			{
				throw new Exception("Failed to return values: {await response.Content.ReadAsStringAsync()}");
			}
		}
		public async Task<EnergyResponse> GetOverviewEnergy(long plantId, DateTimeOffset? date, string language = "en")
		{
			if (!date.HasValue)
			{
				date = DateTimeOffset.Now;
			}

			var response = await this._httpClient.GetAsync($"{this._settings.Url}/v1/plant/energy/{plantId}/day?lan={language}&date={this.ToShortDate(date.Value)}&id={plantId}");
			if (response != null && response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				if (!string.IsNullOrEmpty(responseString))
				{
					return JsonSerializer.Deserialize<EnergyResponse>(responseString);
				}
				else
				{
					throw new Exception($"Invalid overview energy response");
				}
			}
			else
			{
				throw new Exception($"Failed to return values: {await response.Content.ReadAsStringAsync()}");
			}
		}
		public async Task<ProductionResponse> GetOverviewProduction(long plantId)
		{
			var response = await this._httpClient.GetAsync($"{this._settings.Url}/v1/plant/{plantId}/realtime?id={plantId}");
			if (response != null && response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				if (!string.IsNullOrEmpty(responseString))
				{
					return JsonSerializer.Deserialize<ProductionResponse>(responseString);
				}
				else
				{
					throw new Exception($"Invalid overview production response");
				}
			}
			else
			{
				throw new Exception($"Failed to return values: {await response.Content.ReadAsStringAsync()}");
			}
		}

		public async Task<FlowResponse> GetOverviewEnergyFlow(long plantId, DateTimeOffset? date)
		{
			if (!date.HasValue)
			{
				date = DateTimeOffset.Now;
			}

			var response = await this._httpClient.GetAsync($"{this._settings.Url}/v1/plant/energy/{plantId}/flow?date={this.ToShortDate(date.Value)}");
			if (response != null && response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				if (!string.IsNullOrEmpty(responseString))
				{
					return JsonSerializer.Deserialize<FlowResponse>(responseString);
				}
				else
				{
					throw new Exception($"Invalid overview plant flow response");
				}
			}
			else
			{
				throw new Exception($"Failed to return values: {await response.Content.ReadAsStringAsync()}");
			}
		}

		public async Task<WeatherResponse> GetOverviewWeather(string lonlat = "-25.706774,28.259229", string language = "en", DateTimeOffset? date = null)
		{
			if (!date.HasValue)
			{
				date = DateTimeOffset.Now;
			}

			var response = await this._httpClient.GetAsync($"{this._settings.Url}/v1/weather?lan={language}&date={this.ToShortDate(date.Value)}&lonLat={lonlat}");
			if (response != null && response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				if (!string.IsNullOrEmpty(responseString))
				{
					return JsonSerializer.Deserialize<WeatherResponse>(responseString);
				}
				else
				{
					throw new Exception($"Invalid overview weather response");
				}
			}
			else
			{
				throw new Exception($"Failed to return values: {await response.Content.ReadAsStringAsync()}");
			}
		}

		public async Task<GenerationPurposeResponse> GetOverviewGenerationPurpose(long plantId)
		{
			var response = await this._httpClient.GetAsync($"{this._settings.Url}/v1/plant/energy/{plantId}/generation/use");
			if (response != null && response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				if (!string.IsNullOrEmpty(responseString))
				{
					return JsonSerializer.Deserialize<GenerationPurposeResponse>(responseString);
				}
				else
				{
					throw new Exception($"Invalid overview weather response");
				}
			}
			else
			{
				throw new Exception($"Failed to return values: {await response.Content.ReadAsStringAsync()}");
			}
		}
		public async Task<AbnormalStatisticsResponse> GetAbnormalStatistics(long plantId)
		{
			var response = await this._httpClient.GetAsync($"{this._settings.Url}/v1/plant/{plantId}/eventCount");
			if (response != null && response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				if (!string.IsNullOrEmpty(responseString))
				{
					return JsonSerializer.Deserialize<AbnormalStatisticsResponse>(responseString);
				}
				else
				{
					throw new Exception($"Invalid overview weather response");
				}
			}
			else
			{
				throw new Exception($"Failed to return values: {await response.Content.ReadAsStringAsync()}");
			}
		}
		public async Task<UserInfoResponse> GetUserInfo(string language = "en")
		{
			var response = await this._httpClient.GetAsync($"{this._settings.Url}/v1/user?lan={language}");
			if (response != null && response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				if (!string.IsNullOrEmpty(responseString))
				{
					return JsonSerializer.Deserialize<UserInfoResponse>(responseString);
				}
				else
				{
					throw new Exception($"Invalid overview user info response");
				}
			}
			else
			{
				throw new Exception($"Failed to return values: {await response.Content.ReadAsStringAsync()}");
			}
		}

		public async Task<PlantInformationResponse> GetOverviewPlantInfo(long plantId, string language = "en")
		{
			var response = await this._httpClient.GetAsync($"{this._settings.Url}/v1/plant/{plantId}?lan={language}&id={plantId}");
			if (response != null && response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				if (!string.IsNullOrEmpty(responseString))
				{
					return JsonSerializer.Deserialize<PlantInformationResponse>(responseString);
				}
				else
				{
					throw new Exception($"Invalid overview user info response");
				}
			}
			else
			{
				throw new Exception($"Failed to return values: {await response.Content.ReadAsStringAsync()}");
			}
		}

		#endregion

		#region Other Methods

		private string ToShortDate(DateTimeOffset date)
		{
			return date.ToString("yyyy-MM-dd");
		}

		#endregion
	}
}