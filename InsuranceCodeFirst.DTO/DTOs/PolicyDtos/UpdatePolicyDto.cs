namespace InsuranceCodeFirst.DTO.DTOs.PolicyDtos;

public record UpdatePolicyDto(int PolicyId, string PolicyNumber, DateTime StartDate, DateTime EndDate, decimal Price, int CustomerId, int InsurancePackageId, bool IsActive);
