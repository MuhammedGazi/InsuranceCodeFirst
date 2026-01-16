namespace InsuranceCodeFirst.DTO.DTOs.ForecastData
{
    public class CityForecastPrediction
    {
        public float[] ForecastedValues { get; set; }
        public float[] LowerBoundValues { get; set; }
        public float[] UpperBoundValues { get; set; }
    }
}
