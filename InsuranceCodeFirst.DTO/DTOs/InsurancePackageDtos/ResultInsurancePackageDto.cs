using InsuranceCodeFirst.DTO.DTOs.CategoryDtos;

namespace InsuranceCodeFirst.DTO.DTOs.InsuranceDtos;

public record ResultInsurancePackageDto(int InsurancePackageId, string InsurancePackageName, decimal BasePrice, string Details, int CategoryId, ResulCategoryDto Category);

