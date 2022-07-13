namespace Api.Authentication.Plants.Responses
{
	using System;
	using System.Text.Json.Serialization;
	public partial class PlantsInfo
	{
		[JsonPropertyName("id")]
		public long Id { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("thumbUrl")]
		public Uri ThumbUrl { get; set; }

		[JsonPropertyName("status")]
		public long Status { get; set; }

		[JsonPropertyName("address")]
		public string Address { get; set; }

		[JsonPropertyName("pac")]
		public long Pac { get; set; }

		[JsonPropertyName("efficiency")]
		public double Efficiency { get; set; }

		[JsonPropertyName("etoday")]
		public double Etoday { get; set; }

		[JsonPropertyName("etotal")]
		public double Etotal { get; set; }

		[JsonPropertyName("updateAt")]
		public DateTimeOffset UpdateAt { get; set; }

		[JsonPropertyName("createAt")]
		public DateTimeOffset CreateAt { get; set; }

		[JsonPropertyName("type")]
		public long Type { get; set; }

		[JsonPropertyName("masterId")]
		public long MasterId { get; set; }

		[JsonPropertyName("share")]
		public bool Share { get; set; }

		[JsonPropertyName("plantPermission")]
		public string[] PlantPermission { get; set; }
	}
}
