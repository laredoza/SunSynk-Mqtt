namespace Api.Authentication.Overview.Responses.Flows
{
	using System.Text.Json.Serialization;

	public partial class FlowResponse
	{
		[JsonPropertyName("code")]
		public long Code { get; set; }

		[JsonPropertyName("msg")]
		public string Msg { get; set; }

		[JsonPropertyName("data")]
		public FlowData Data { get; set; }

		[JsonPropertyName("success")]
		public bool Success { get; set; }
	}
}
