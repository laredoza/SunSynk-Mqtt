namespace Api.Authentication.Overview.Responses.PlantInformation
{
	using System;
	using System.Text.Json.Serialization;

	public partial class PlantInformationResponse
	{
		[JsonPropertyName("code")]
		public long Code { get; set; }

		[JsonPropertyName("msg")]
		public string Msg { get; set; }

		[JsonPropertyName("data")]
		public PlantInformationData Data { get; set; }

		[JsonPropertyName("success")]
		public bool Success { get; set; }
	}

	public partial class PlantInformationData
	{
		[JsonPropertyName("id")]
		public long Id { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("totalPower")]
		public double TotalPower { get; set; }

		[JsonPropertyName("thumbUrl")]
		public Uri ThumbUrl { get; set; }

		[JsonPropertyName("joinDate")]
		public DateTimeOffset JoinDate { get; set; }

		[JsonPropertyName("type")]
		public long Type { get; set; }

		[JsonPropertyName("status")]
		public long Status { get; set; }

		[JsonPropertyName("charges")]
		public Charge[] Charges { get; set; }

		[JsonPropertyName("products")]
		public object Products { get; set; }

		[JsonPropertyName("lon")]
		public double Lon { get; set; }

		[JsonPropertyName("lat")]
		public double Lat { get; set; }

		[JsonPropertyName("address")]
		public string Address { get; set; }

		[JsonPropertyName("master")]
		public Master Master { get; set; }

		[JsonPropertyName("currency")]
		public PlantInformationCurrency Currency { get; set; }

		[JsonPropertyName("timezone")]
		public string Timezone { get; set; }

		[JsonPropertyName("realtime")]
		public Realtime Realtime { get; set; }

		[JsonPropertyName("createAt")]
		public DateTimeOffset CreateAt { get; set; }

		[JsonPropertyName("phone")]
		public string Phone { get; set; }

		[JsonPropertyName("email")]
		public string Email { get; set; }

		[JsonPropertyName("installer")]
		public string Installer { get; set; }

		[JsonPropertyName("principal")]
		public string Principal { get; set; }

		[JsonPropertyName("plantPermission")]
		public string[] PlantPermission { get; set; }

		[JsonPropertyName("invest")]
		public double Invest { get; set; }
	}

	public partial class Charge
	{
		[JsonPropertyName("id")]
		public long Id { get; set; }

		[JsonPropertyName("startRange")]
		public string StartRange { get; set; }

		[JsonPropertyName("endRange")]
		public string EndRange { get; set; }

		[JsonPropertyName("price")]
		public double Price { get; set; }

		[JsonPropertyName("type")]
		public long Type { get; set; }

		[JsonPropertyName("stationId")]
		public long StationId { get; set; }

		[JsonPropertyName("createAt")]
		public DateTimeOffset CreateAt { get; set; }
	}

	public partial class PlantInformationCurrency
	{
		[JsonPropertyName("id")]
		public long Id { get; set; }

		[JsonPropertyName("code")]
		public string Code { get; set; }

		[JsonPropertyName("text")]
		public string Text { get; set; }
	}

	public partial class Master
	{
		[JsonPropertyName("id")]
		public long Id { get; set; }

		[JsonPropertyName("nickname")]
		public string Nickname { get; set; }

		[JsonPropertyName("mobile")]
		public object Mobile { get; set; }
	}

	public partial class Realtime
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
		public PlantInformationCurrency Currency { get; set; }

		[JsonPropertyName("totalPower")]
		public double TotalPower { get; set; }
	}
}
