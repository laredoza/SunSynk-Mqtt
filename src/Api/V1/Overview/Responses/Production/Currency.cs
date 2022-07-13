namespace Api.Authentication.Overview.Responses.Production
{
	using System;
	using System.Text.Json.Serialization;

	public partial class Currency
	{
		[JsonPropertyName("id")]
		public long Id { get; set; }

		[JsonPropertyName("code")]
		public string Code { get; set; }

		[JsonPropertyName("text")]
		public string Text { get; set; }
	}
}
