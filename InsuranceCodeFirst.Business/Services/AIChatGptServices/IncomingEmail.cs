using InsuranceCodeFirst.DTO.DTOs.AIChatGptDtos;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace InsuranceCodeFirst.Business.Services.AIChatGptServices
{
    public class GeminiService
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;
        private const string Model = "gemini-2.5-flash";
        private const string BaseUrl = "https://generativelanguage.googleapis.com/v1beta/models/";

        public GeminiService(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _apiKey = configuration["Gemini:ApiKey"];
        }

        public async Task<AIResponseModel> GetAiResponseAsync(string incomingEmailBody)
        {
            var prompt = incomingEmailBody +
                         " Sen yardımsever bir müşteri temsilcisisin. Gelen e-postayı analiz et. " +
                         "1. E-postanın dilini tespit et (Turkish, English, German vb.). " +
                         "2. O dilde nazik, profesyonel ve çözüm odaklı bir yanıt taslağı oluştur. " +
                         "3. Yanıtı SADECE geçerli bir JSON formatında ver, başka hiçbir açıklama yazma: { \"language\": \"...\", \"replyBody\": \"...\" }";

            var request = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[] { new { text = prompt } }
                    }
                },
                generationConfig = new
                {
                    temperature = 0.4,
                    responseMimeType = "application/json"
                }
            };

            var jsonContent = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var url = $"{BaseUrl}{Model}:generateContent?key={_apiKey}";

            try
            {
                var response = await _client.PostAsync(url, httpContent);

                if (!response.IsSuccessStatusCode)
                {
                    var errorMsg = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Gemini API Hatası: {errorMsg}");
                }

                var responseString = await response.Content.ReadAsStringAsync();

                dynamic geminiResponse = JsonConvert.DeserializeObject(responseString);
                string resultText = geminiResponse?.candidates?[0]?.content?.parts?[0]?.text;

                if (string.IsNullOrEmpty(resultText))
                {
                    throw new Exception("Gemini boş yanıt döndü.");
                }

                resultText = resultText.Replace("```json", "").Replace("```", "").Trim();
                return JsonConvert.DeserializeObject<AIResponseModel>(resultText);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"AI Servis Hatası: {ex.Message}");
                return new AIResponseModel
                {
                    Language = "Unknown",
                    ReplyBody = "Otomatik yanıt servisi şu an kullanılamıyor, lütfen manuel kontrol sağlayın."
                };
            }
        }
    }
}