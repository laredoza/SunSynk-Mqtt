namespace Api.Authentication.Configuration
{
	public class AuthenticationServiceOptions<T> : IAuthenticationServiceOptions<T>
	{
		public string Url { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string GrantType { get; set; }
		public string ClientId { get; set; }
	}
}
