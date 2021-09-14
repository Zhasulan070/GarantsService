using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GarantsService.Helpers
{
    public class RequestHelper
    {
        public static async Task<T> SendPostRequestAsync<T>(string Url, object ClientContent) 
        {
            T resHttp;
            var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(200);
            var content = new StringContent(JsonConvert.SerializeObject(ClientContent), Encoding.UTF8, "application/json");
            using var response = await client.PostAsync(Url, content);
            var apiResponse = await response.Content.ReadAsStringAsync();
            resHttp = JsonConvert.DeserializeObject<T>(apiResponse);

            return resHttp;
        }

        public static async Task<T> SendGetRequestAsync<T>(string Url)
        {
            T resHttp;
            var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(200);
            using var response = await client.GetAsync(Url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            resHttp = JsonConvert.DeserializeObject<T>(apiResponse);

            return resHttp;
        }

    }
}