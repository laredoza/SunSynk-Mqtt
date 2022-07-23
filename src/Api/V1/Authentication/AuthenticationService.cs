using Api.Authentication.Configuration;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Api.Extensions;
using Api.Authentication.Payload;
using System.Text.Json;
using Api.Authentication.Response;

namespace Api.Authentication
{
	public class AuthenticationService<T> : IAuthenticationService<T>
	{
		#region Fields

		readonly AuthenticationServiceOptions<T> _serviceOptions;
		readonly HttpClient _httpClient;

		#endregion

		#region Constructors

		public AuthenticationService(
			HttpClient client, 
			IOptionsMonitor<AuthenticationServiceOptions<T>> serviceOptions)
		{
			_httpClient = client;
			_serviceOptions = serviceOptions?.CurrentValue;
		}
		#endregion
		#region Public Methods
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
		#endregion
		#region Private Methods
		#endregion
	}
}