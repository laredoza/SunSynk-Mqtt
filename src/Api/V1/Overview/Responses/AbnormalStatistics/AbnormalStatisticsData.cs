using System.Text.Json.Serialization;
namespace Api.Authentication.Overview.Responses.AbnormalStatistics
{
	public partial class AbnormalStatisticsData
	{
		[JsonPropertyName("warning")]
		public long Warning { get; set; }

		[JsonPropertyName("fault")]
		public long Fault { get; set; }

		[JsonPropertyName("updateAt")]
		public DateTimeOffset UpdateAt { get; set; }
	}
}
