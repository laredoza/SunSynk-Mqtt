namespace Api.Authentication.Overview.Responses.Energy
{
	using System.Text.Json.Serialization;
	public partial class Record
	{
		[JsonPropertyName("time")]
		public string Time { get; set; }

		[JsonPropertyName("value")]
		public string Value { get; set; }

		[JsonPropertyName("updateTime")]
		public object UpdateTime { get; set; }
	}
}
