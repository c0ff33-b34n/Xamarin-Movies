using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Movies
{
    public class NetworkService
    {
        private HttpClient _httpClient;

        public NetworkService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<TResult> GetAsync<TResult>(string uri)
        {
            HttpResponseMessage response =  await _httpClient.GetAsync(uri);
            string serialized = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TResult>(serialized);
            return result;
        }
    }
}
