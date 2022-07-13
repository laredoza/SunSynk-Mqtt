namespace Api.Authentication.Overview.Responses.Energy
{
	using System.Text.Json.Serialization;

	public partial class EnergyResponse
	{
		[JsonPropertyName("code")]
		public long Code { get; set; }

		[JsonPropertyName("msg")]
		public string Msg { get; set; }

		[JsonPropertyName("data")]
		public Data Data { get; set; }

		[JsonPropertyName("success")]
		public bool Success { get; set; }
	}
}
