
using System.Text.Json.Serialization;
namespace Api.Authentication.Overview.Responses.AbnormalStatistics
{
	public partial class AbnormalStatisticsResponse
	{
		[JsonPropertyName("code")]
		public long Code { get; set; }

		[JsonPropertyName("msg")]
		public string Msg { get; set; }

		[JsonPropertyName("data")]
		public AbnormalStatisticsData Data { get; set; }

		[JsonPropertyName("success")]
		public bool Success { get; set; }
	}
}
