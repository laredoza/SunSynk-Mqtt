namespace Api.Authentication.Overview.Responses.Production
{
	using System;
	using System.Text.Json.Serialization;
	public partial class ProductionData
	{
		[JsonPropertyName("pac")]
		public long Pac { get; set; }

		[JsonPropertyName("etoday")]
		public double Etoday { get; set; }

		[JsonPropertyName("emonth")]
		public double Emonth { get; set; }

		[JsonPropertyName("eyear")]
		public double Eyear { get; set; }

		[JsonPropertyName("etotal")]
		public double Etotal { get; set; }

		[JsonPropertyName("income")]
		public double Income { get; set; }

		[JsonPropertyName("efficiency")]
		public double Efficiency { get; set; }

		[JsonPropertyName("updateAt")]
		public DateTimeOffset UpdateAt { get; set; }

		[JsonPropertyName("currency")]
		public Currency Currency { get; set; }

		[JsonPropertyName("totalPower")]
		public double TotalPower { get; set; }
	}
}
