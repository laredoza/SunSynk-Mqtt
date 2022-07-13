namespace Api.Authentication.Response
{
	using System.Text.Json.Serialization;

	public class AuthResponse
	{
		[JsonPropertyName("code")]
		public long Code { get; set; }

		[JsonPropertyName("msg")]
		public string Message { get; set; }

		[JsonPropertyName("data")]
		public DataResponse Data { get; set; }

		[JsonPropertyName("success")]
		public bool Success { get; set; }
	}
}