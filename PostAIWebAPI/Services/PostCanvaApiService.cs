using System;
using System.Net.Http;
using System.Text;

namespace PostAIWebAPI.Services
{
    public class PostCanvaApiService
    {
        private readonly HttpClient _httpClient;

        public PostCanvaApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendPostRequestAsync(string uri, string token, string jsonBody)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri),
                Content = new StringContent(jsonBody, Encoding.UTF8, "application/json")
            };

            request.Headers.Add("Authorization", $"Bearer {token}");

            // Use await diretamente no método SendAsync
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            else
            {
                Console.WriteLine($"Erro: {response.StatusCode}, {response.ReasonPhrase}");
            }
        }
    }
}
