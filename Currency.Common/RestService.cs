using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace Currency.Common
{
    public sealed class RestService
    {
        private static readonly RestService instance = new RestService();

        public static RestService Instance => instance;

        public async Task<T> Get<T>(string url)
        {
            var method = new RestRequest(Method.GET);
            var client = new RestClient(url);

            IRestResponse response = await client.ExecuteAsync(method);

            return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}

