namespace Api.Extensions
{
    #region Usings

    using System.Net.Http;
    using System.Net.Http.Headers;
	using System.Text.Json;
	using System.Threading.Tasks;

    #endregion

    /// <summary>
    ///     Extension uses to simplify http calls 
    /// </summary>
    public static class HttpClientExtensions
    {
        #region Public Properties


        #endregion

        #region Public Methods And Operators

        /// <summary>
        ///     Extension uses to posting json 
        /// </summary>
        public static async Task<HttpResponseMessage> PostAsJsonAsync<T>(
            this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return await httpClient.PostAsync(url, content);
        }
        /// <summary>
        ///     Extension uses to simplify posting xml 
        /// </summary>
        public static async Task<HttpResponseMessage> PostAsXmlAsync<T>(
            this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
            return await httpClient.PostAsync(url, content);
        }
        /// <summary>
        ///     Extension uses to simplify posting xml 
        /// </summary>
        public static async Task<HttpResponseMessage> PostAsXmlAsync<T>(
            this HttpClient httpClient, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("text/xml");
            return await httpClient.PostAsync("", content);
        }
        /// <summary>
        ///     Extension uses to simplify json puts 
        /// </summary>
        public static async Task<HttpResponseMessage> PutAsJsonAsync<T>(
            this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return await httpClient.PutAsync(url, content);
        }

        /// <summary>
        ///     Extension uses to simplify json reads 
        /// </summary>
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            var dataAsString = await content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(dataAsString);
        }

        #endregion

        #region Other Methods

        #endregion
    }
}