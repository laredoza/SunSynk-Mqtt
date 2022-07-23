using System.Text.Json.Serialization;

namespace Api.Authentication.Overview.Responses.Production
{
	public partial class WeatherResponse
	{
		[JsonPropertyName("code")]
		public long Code { get; set; }

		[JsonPropertyName("msg")]
		public string Msg { get; set; }

		[JsonPropertyName("data")]
		public WeatherData Data { get; set; }

		[JsonPropertyName("success")]
		public bool Success { get; set; }
	}
}