namespace Api.Authentication.Overview.Responses.UserInfo
{
	using System;
	using System.Text.Json.Serialization;

	public partial class UserInfoResponse
	{
		[JsonPropertyName("code")]
		public long Code { get; set; }

		[JsonPropertyName("msg")]
		public string Msg { get; set; }

		[JsonPropertyName("data")]
		public UserInfoData Data { get; set; }

		[JsonPropertyName("success")]
		public bool Success { get; set; }
	}

	public partial class UserInfoData
	{
		[JsonPropertyName("id")]
		public long Id { get; set; }

		[JsonPropertyName("nickname")]
		public string Nickname { get; set; }

		[JsonPropertyName("avatar")]
		public Uri Avatar { get; set; }

		[JsonPropertyName("gender")]
		public long Gender { get; set; }

		[JsonPropertyName("mobile")]
		public object Mobile { get; set; }

		[JsonPropertyName("createAt")]
		public DateTimeOffset CreateAt { get; set; }

		[JsonPropertyName("type")]
		public object Type { get; set; }

		[JsonPropertyName("tempUnit")]
		public string TempUnit { get; set; }

		[JsonPropertyName("company")]
		public object Company { get; set; }

		[JsonPropertyName("userSrc")]
		public string UserSrc { get; set; }
	}
}
