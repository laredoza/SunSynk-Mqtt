namespace Api.Authentication.Overview.Responses.Energy
{
	using System.Text.Json.Serialization;
	public partial class Data
	{
		[JsonPropertyName("infos")]
		public Info[] Infos { get; set; }
	}
}
