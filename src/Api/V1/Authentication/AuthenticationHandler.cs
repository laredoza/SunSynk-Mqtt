namespace Api.Authentication
{
	using Api.Authentication.Configuration;
	public class AuthenticationHandler<T> : DelegatingHandler
	{
		readonly IAuthenticationService<T> _authenticationService;
		static string _accessToken;
		static long _expiresIn;

		public AuthenticationHandler(IAuthenticationService<T> authenticationService)
		{
			_authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(_accessToken))
			{
				var accessToken = await _authenticationService.RequestClientCredentialsTokenAsync();

				if (!string.IsNullOrWhiteSpace(accessToken.Data.AccessToken))
				{
					_accessToken = accessToken.Data.AccessToken;
					_expiresIn = accessToken.Data.ExpiresIn;

					request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_accessToken}");

					// Parse JSON response.
				}
			}
			else
			{
				//Todo: Check if token is expired.
				request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_accessToken}");
				// if (DateTime.UtcNow >= token.ValidTo.AddSeconds(-30))
				// {
				// 	var accessToken = await _authenticationService.RequestClientCredentialsTokenAsync();

				// 	if (!string.IsNullOrWhiteSpace(accessToken))
				// 	{
				// 		_accessToken = accessToken;

				// 		request.SetBearerToken(_accessToken);
				// 	}
				// }
				// else
				// {
				// 	request.SetBearerToken(_accessToken);
				// }
			}

			return await base.SendAsync(request, cancellationToken);
		}
	}
}
