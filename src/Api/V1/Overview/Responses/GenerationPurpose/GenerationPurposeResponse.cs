namespace Api.Authentication.Plants.Responses
{
	using System;
	using System.Collections.Generic;
	using System.Text.Json.Serialization;

	public partial class GenerationPurposeResponse
	{
		[JsonPropertyName("code")]
		public long Code { get; set; }

		[JsonPropertyName("msg")]
		public string Msg { get; set; }

		[JsonPropertyName("data")]
		public GenerationPurposeData Data { get; set; }

		[JsonPropertyName("success")]
		public bool Success { get; set; }
	}
}
