using InsuranceCodeFirst.DTO.DTOs.CustomerDtos;
using InsuranceCodeFirst.DTO.DTOs.InsuranceDtos;

namespace InsuranceCodeFirst.DTO.DTOs.PolicyDtos;

public record ResultPolicyDto(int PolicyId, string PolicyNumber, DateTime StartDate, DateTime EndDate, decimal Price, int CustomerId, ResultCustomerDto Customer, int InsurancePackageId, ResultInsurancePackageDto InsurancePackage, bool IsActive);
