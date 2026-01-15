namespace InsuranceCodeFirst.Entity.Entities;

public class Policy
{
    public int PolicyId { get; set; }
    public string PolicyNumber { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Price { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public int InsurancePackageId { get; set; }
    public InsurancePackage InsurancePackage { get; set; }

    public bool IsActive { get; set; }
}
