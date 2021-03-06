namespace Api.Authentication.Overview.Responses.Flows
{
	using System.Text.Json.Serialization;

	public partial class FlowData
	{
		[JsonPropertyName("custCode")]
		public long CustCode { get; set; }

		[JsonPropertyName("meterCode")]
		public long MeterCode { get; set; }

		[JsonPropertyName("pvPower")]
		public long PvPower { get; set; }

		[JsonPropertyName("battPower")]
		public long BattPower { get; set; }

		[JsonPropertyName("gridOrMeterPower")]
		public long GridOrMeterPower { get; set; }

		[JsonPropertyName("loadOrEpsPower")]
		public long LoadOrEpsPower { get; set; }

		[JsonPropertyName("genPower")]
		public long GenPower { get; set; }

		[JsonPropertyName("minPower")]
		public long MinPower { get; set; }

		[JsonPropertyName("soc")]
		public double Soc { get; set; }

		[JsonPropertyName("pvTo")]
		public bool PvTo { get; set; }

		[JsonPropertyName("toLoad")]
		public bool ToLoad { get; set; }

		[JsonPropertyName("toGrid")]
		public bool ToGrid { get; set; }

		[JsonPropertyName("toBat")]
		public bool ToBat { get; set; }

		[JsonPropertyName("batTo")]
		public bool BatTo { get; set; }

		[JsonPropertyName("gridTo")]
		public bool GridTo { get; set; }

		[JsonPropertyName("genTo")]
		public bool GenTo { get; set; }

		[JsonPropertyName("minTo")]
		public bool MinTo { get; set; }

		[JsonPropertyName("existsGen")]
		public bool ExistsGen { get; set; }

		[JsonPropertyName("existsMin")]
		public bool ExistsMin { get; set; }

		[JsonPropertyName("genOn")]
		public bool GenOn { get; set; }

		[JsonPropertyName("microOn")]
		public bool MicroOn { get; set; }

		[JsonPropertyName("existsMeter")]
		public bool ExistsMeter { get; set; }
	}
}
