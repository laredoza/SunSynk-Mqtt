namespace Api.Authentication
{
	using Api.Authentication.Configuration;
	public class AuthenticationHandler<T> : DelegatingHandler
	{
		readonly IAuthenticationService<T> _authenticationService;
		static string _accessToken;
		static DateTimeOffset _expiration;

		public AuthenticationHandler(IAuthenticationService<T> authenticationService)
		{
			_authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(_accessToken))
			{
				var accessToken = await _authenticationService.RequestClientCredentialsTokenAsync();

				if (accessToken.Success && !string.IsNullOrWhiteSpace(accessToken.Data.AccessToken))
				{
					_accessToken = accessToken.Data.AccessToken;
					_expiration = (DateTime.UtcNow.AddSeconds(accessToken.Data.ExpiresIn - 30)).ToUniversalTime();
					request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_accessToken}");
				}
			}
			else
			{
				//Todo: Confirm that ExpiresIn is in seconds 
				if (DateTime.UtcNow >= _expiration)
				{
					var accessToken = await _authenticationService.RequestClientCredentialsTokenAsync();

					if (accessToken.Success && !string.IsNullOrWhiteSpace(accessToken.Data.AccessToken))
					{
						_accessToken = accessToken.Data.AccessToken;
						_expiration = (DateTime.UtcNow.AddSeconds(accessToken.Data.ExpiresIn - 30)).ToUniversalTime();
						request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_accessToken}");
					}
				}
				else
				{
					request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_accessToken}");
				}
			}

			return await base.SendAsync(request, cancellationToken);
		}
	}
}
