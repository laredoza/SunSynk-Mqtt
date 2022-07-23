using System.Text.Json.Serialization;

namespace Api.Authentication.Overview.Responses.Production
{
	public partial class CurrWeather
	{
		[JsonPropertyName("desc")]
		public string Description { get; set; }

		[JsonPropertyName("currTemp")]
		public string CurrentTempreture { get; set; }

		[JsonPropertyName("windSpeed")]
		public string WindSpeed { get; set; }

		[JsonPropertyName("windDirection")]
		public string WindDirection { get; set; }

		[JsonPropertyName("sunrise")]
		public string Sunrise { get; set; }

		[JsonPropertyName("sunset")]
		public string Sunset { get; set; }

		[JsonPropertyName("iconUrl")]
		public Uri IconUrl { get; set; }

		[JsonPropertyName("tempMinC")]
		public string TempMinC { get; set; }

		[JsonPropertyName("tempMaxC")]
		public string TempMaxC { get; set; }
	}
}