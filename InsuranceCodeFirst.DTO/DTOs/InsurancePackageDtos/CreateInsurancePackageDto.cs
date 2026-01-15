namespace InsuranceCodeFirst.DTO.DTOs.InsuranceDtos;

public record CreateInsurancePackageDto(string InsurancePackageName, decimal BasePrice, string Details, int CategoryId);
