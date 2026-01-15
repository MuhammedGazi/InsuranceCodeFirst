namespace InsuranceCodeFirst.DTO.DTOs.InsuranceDtos;

public record UpdateInsurancePackageDto(int InsurancePackageId, string InsurancePackageName, decimal BasePrice, string Details, int CategoryId);
