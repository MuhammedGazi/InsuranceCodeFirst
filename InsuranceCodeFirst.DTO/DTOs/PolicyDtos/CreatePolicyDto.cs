namespace InsuranceCodeFirst.DTO.DTOs.PolicyDtos;

public record CreatePolicyDto(string PolicyNumber, DateTime StartDate, DateTime EndDate, decimal Price, int CustomerId, int InsurancePackageId, bool IsActive);

