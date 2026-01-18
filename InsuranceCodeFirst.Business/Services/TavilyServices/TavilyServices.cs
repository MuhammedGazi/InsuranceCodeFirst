using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace InsuranceCodeFirst.Business.Services.TavilyServices
{
    public class TavilyServices : ITavilyServices
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;

        public TavilyServices(IConfiguration configuration, HttpClient client)
        {
            _apiKey = configuration["TavilyApi:ApiKey"];
            _client = client;
        }

        public async Task<string> GetSearchQueryResultAsync(string query)
        {
            var requestBody = new
            {
                api_key = _apiKey,
                query = query,
                search_depth = "basic",
                include_answer = true
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("https://api.tavily.com/search", content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(jsonResponse);

                if (doc.RootElement.TryGetProperty("answer", out var answerElement))
                {
                    return answerElement.GetString() ?? "Sonuç Bulunamadı";
                }
            }

            return "Üzgünüm şu an araştırma yapamıyorum";
        }
    }
}
