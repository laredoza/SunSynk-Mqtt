namespace Api.Authentication.Overview.Responses.Energy
{
	using System.Text.Json.Serialization;
	public partial class Info
	{
		[JsonPropertyName("unit")]
		public string Unit { get; set; }

		[JsonPropertyName("records")]
		public Record[] Records { get; set; }

		[JsonPropertyName("id")]
		public object Id { get; set; }

		[JsonPropertyName("label")]
		public string Label { get; set; }

		[JsonPropertyName("groupCode")]
		public object GroupCode { get; set; }

		[JsonPropertyName("name")]
		public object Name { get; set; }
	}
}
