namespace Api.Authentication.Overview.Responses.Production
{
	using System;
	using System.Text.Json.Serialization;

	public partial class ProductionResponse
	{
		[JsonPropertyName("code")]
		public long Code { get; set; }

		[JsonPropertyName("msg")]
		public string Msg { get; set; }

		[JsonPropertyName("data")]
		public ProductionData Data { get; set; }

		[JsonPropertyName("success")]
		public bool Success { get; set; }
	}
}
