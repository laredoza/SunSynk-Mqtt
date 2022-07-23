using System.Text.Json.Serialization;

namespace Api.Authentication.Overview.Responses.Plants
{
	public partial class PlantsData
	{
		[JsonPropertyName("pageSize")]
		public long PageSize { get; set; }

		[JsonPropertyName("pageNumber")]
		public long PageNumber { get; set; }

		[JsonPropertyName("total")]
		public long Total { get; set; }

		[JsonPropertyName("infos")]
		public PlantsInfo[] Infos { get; set; }
	}
}
