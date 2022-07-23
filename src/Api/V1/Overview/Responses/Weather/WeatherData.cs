using System.Text.Json.Serialization;

namespace Api.Authentication.Overview.Responses.Production
{
	public partial class WeatherData
	{
		[JsonPropertyName("currWea")]
		public CurrWeather CurrentWeather { get; set; }
	}
}