namespace RealtyWeb_Client.Utils
{
    public class YandexService
    {
        private readonly HttpClient httpClient;

        public YandexService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public string GetBaseUrl()
        {
            string url = string.Empty;
            url = httpClient.BaseAddress != null ? httpClient.BaseAddress.ToString() : string.Empty;
            return url;
        }
    }
}
