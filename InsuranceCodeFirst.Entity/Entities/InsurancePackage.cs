namespace InsuranceCodeFirst.Entity.Entities;

public class InsurancePackage
{
    public int InsurancePackageId { get; set; }
    public string InsurancePackageName { get; set; }
    public decimal BasePrice { get; set; }
    public string Details { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public IList<Policy> Policies { get; set; }
}
