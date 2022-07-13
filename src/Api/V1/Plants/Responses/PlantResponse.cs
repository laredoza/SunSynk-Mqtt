namespace Api.Authentication.Plants.Responses
{
	using System.Text.Json.Serialization;
	public partial class PlantsResponse
	{
		[JsonPropertyName("code")]
		public long Code { get; set; }

		[JsonPropertyName("msg")]
		public string Msg { get; set; }

		[JsonPropertyName("data")]
		public PlantsData Data { get; set; }

		[JsonPropertyName("success")]
		public bool Success { get; set; }
	}
}
