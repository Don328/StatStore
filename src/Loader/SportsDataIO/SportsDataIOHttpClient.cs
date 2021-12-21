using StatStore.Loader.SportsDataIO.Interfaces;

namespace StatStore.Loader.SportsDataIO
{
    public class SportsDataIOHttpClient : ICustomHttpClient
    {
        private readonly HttpClient client;

        public SportsDataIOHttpClient(IConfiguration config)
        {
            var key = config.GetSection("SportsData:RequestHeader").Value;
            var value = config.GetSection("SportsData:ApiKey").Value;


            client = GetClient(key, value);
        }

        public HttpClient Client { get { return client; } }


        private HttpClient GetClient(string key, string value)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add(key, value);
            return client;
        }
    }
}
