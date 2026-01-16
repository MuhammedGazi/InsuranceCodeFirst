namespace InsuranceCodeFirst.DTO.DTOs.ForecastData
{
    public class ForecastResultDto
    {
        public string City { get; set; }

        public string Category { get; set; }

        public string Package { get; set; }

        public int ForecastedCount { get; set; }

        public decimal EstimatedRevenue { get; set; }
    }
}
