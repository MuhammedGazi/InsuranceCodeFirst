using System.Text.Json.Serialization;

namespace InsuranceCodeFirst.DTO.DTOs.HugginFaceDtos
{
    public class GradioResponseDto
    {
        [JsonPropertyName("data")]
        public List<ClassificationResult>? Data { get; set; }
    }

    public class ClassificationResult
    {
        [JsonPropertyName("Tespit_Edilen_Kategori")]
        public string Kategori { get; set; }

        [JsonPropertyName("Guven_Orani")]
        public string GuvenOrani { get; set; }
    }

    public class HfInferenceResponse
    {
        [JsonPropertyName("labels")]
        public List<string> Labels { get; set; }

        [JsonPropertyName("scores")]
        public List<double> Scores { get; set; }
    }

    public class HfPrediction
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("score")]
        public double Score { get; set; }
    }
}
