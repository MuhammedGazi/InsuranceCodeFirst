namespace InsuranceCodeFirst.DTO.DTOs.DashboardDtos;

public class ResultDashboardDto
{
    public int CustomerCount { get; set; }
    public int PolicyActiveCount { get; set; }
    public decimal PolicyPriceCount { get; set; }
    public decimal PolicyPriceAvgCount { get; set; }
    public string PolicyMostInsurancePackageCount { get; set; }
    public string PolicyCategoryMostPriceCount { get; set; }
    public decimal PolicyFalseAvgCount { get; set; }
    public string PolicyMostCityCustomerCount { get; set; }
    public int PolicyLoyaltyCustomer { get; set; }
    public int PolicyEndDate { get; set; }
    public decimal PolicyMaxPrice { get; set; }
    public decimal PolicyWaitPrice { get; set; }
    public string MostMonthName { get; set; }
    public string PolicyMinPrice { get; set; }
    public string ExpensiveCustomer { get; set; }
    public int PotentialCustomerCount { get; set; }
}
