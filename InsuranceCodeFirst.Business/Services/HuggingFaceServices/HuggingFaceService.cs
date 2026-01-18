using InsuranceCodeFirst.DTO.DTOs.HugginFaceDtos;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace InsuranceCodeFirst.Business.Services.HuggingFaceServices
{
    public class HuggingFaceService : IHuggingFaceService
    {
        private readonly HttpClient _httpClient;

        public HuggingFaceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ClassificationResult?> AnalizEtAsync(string metin)
        {
            var url = "https://router.huggingface.co/hf-inference/models/vicgalle/xlm-roberta-large-xnli-anli";

            var requestData = new
            {
                inputs = metin,
                parameters = new
                {
                    candidate_labels = new[] { "Şikayet", "Teşekkür", "Rica", "Bilgi İsteği", "İade Talebi", "Randevu" }
                }
            };

            var jsonContent = new StringContent(
                JsonSerializer.Serialize(requestData),
                Encoding.UTF8,
                "application/json");

            try
            {
                // Token'ını buraya ekle
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", "");

                var response = await _httpClient.PostAsync(url, jsonContent);
                var responseString = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"API Hatası: {responseString}");
                    return null;
                }

                // --- DÜZELTİLEN KISIM ---
                // Gelen veri doğrudan bir liste: [{"label":"...","score":...}, ...]
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                var predictions = JsonSerializer.Deserialize<List<HfPrediction>>(responseString, options);

                // En yüksek skorlu olan genelde ilk sıradadır ama biz yine de Score'a göre sıralayıp ilkini alalım
                var bestPrediction = predictions?.OrderByDescending(x => x.Score).FirstOrDefault();

                if (bestPrediction != null)
                {
                    return new ClassificationResult
                    {
                        Kategori = bestPrediction.Label,
                        GuvenOrani = $"%{bestPrediction.Score * 100:0.00}"
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return null;
            }
        }
    }
}
