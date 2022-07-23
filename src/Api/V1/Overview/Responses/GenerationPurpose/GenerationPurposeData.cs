namespace Api.Authentication.Overview.Responses.GenerationPurpose
{
	using System;
	using System.Collections.Generic;
	using System.Text.Json.Serialization;
	public partial class GenerationPurposeData
	{
		[JsonPropertyName("load")]
		public double Load { get; set; }

		[JsonPropertyName("pv")]
		public double Pv { get; set; }

		[JsonPropertyName("batteryCharge")]
		public double BatteryCharge { get; set; }

		[JsonPropertyName("gridSell")]
		public double GridSell { get; set; }
	}
}
