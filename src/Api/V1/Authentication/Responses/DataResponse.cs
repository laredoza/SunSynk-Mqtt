using System.Text.Json.Serialization;

namespace Api.Authentication.Response;

public class DataResponse
{
	[JsonPropertyName("access_token")]
	public string AccessToken { get; set; }

	[JsonPropertyName("token_type")]
	public string TokenType { get; set; }

	[JsonPropertyName("refresh_token")]
	public string RefreshToken { get; set; }

	[JsonPropertyName("expires_in")]
	public long ExpiresIn { get; set; }

	[JsonPropertyName("scope")]
	public string Scope { get; set; }
}