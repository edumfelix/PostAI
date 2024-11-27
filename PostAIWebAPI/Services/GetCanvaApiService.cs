using System;
using System.Net.Http;
using System.Threading.Tasks;

public class GetCanvaApiService
{
    private readonly HttpClient _httpClient;

    public GetCanvaApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetJobDetailsAsync(string jobId, string token)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://api.canva.com/rest/v1/autofills/{jobId}"),
            Headers =
            {
                { "Authorization", $"Bearer {token}" }
            }
        };

        using var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}
