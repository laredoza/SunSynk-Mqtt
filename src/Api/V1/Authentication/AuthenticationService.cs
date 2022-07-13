using Api.Authentication.Configuration;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Api.Extensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Authentication.Payload;
using System.Text.Json;
using Api.Authentication.Response;

namespace Api.Authentication
{
	public class AuthenticationService<T> : IAuthenticationService<T>
	{
		#region Fields

		readonly IMemoryCache _memoryCache;
		readonly AuthenticationServiceOptions<T> _serviceOptions;
		readonly HttpClient _httpClient;
		// DiscoveryDocumentResponse _discoveryDocument;

		#endregion

		#region Constructors

		public AuthenticationService(HttpClient client, IMemoryCache memoryCache, IOptionsMonitor<AuthenticationServiceOptions<T>> serviceOptions)
		{
			_httpClient = client;
			_memoryCache = memoryCache;
			_serviceOptions = serviceOptions?.CurrentValue;
		}

		#endregion

		public async Task<AuthResponse> RequestClientCredentialsTokenAsync()
		{
			var payload = new AuthPayload
			{
				Username = this._serviceOptions.Username, 
				Password = this._serviceOptions.Password, 
				GrantType = this._serviceOptions.GrantType, 
				ClientId = this._serviceOptions.ClientId 

			};

			var response = await this._httpClient.PostAsJsonAsync($"{this._serviceOptions.Url}/oauth/token", payload);

			if (response.IsSuccessStatusCode)
			{
				var stringResponse = await response.Content.ReadAsStringAsync();
				return JsonSerializer.Deserialize<AuthResponse>(stringResponse);
			}
			else
			{
				//Todo: Log failure 
				throw new Exception("Failed to request token");
			}
		}

		#region Private Methods
		#endregion
	}
}