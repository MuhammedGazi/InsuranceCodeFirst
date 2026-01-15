using System.ComponentModel.DataAnnotations;

namespace InsuranceCodeFirst.Entity.Entities;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    public string CategoryName { get; set; }
    public string Description { get; set; }

    public IList<InsurancePackage> InsurancePackages { get; set; }
}
