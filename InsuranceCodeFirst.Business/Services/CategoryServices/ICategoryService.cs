using InsuranceCodeFirst.DTO.DTOs.CategoryDtos;

namespace InsuranceCodeFirst.Business.Services.CategoryServices
{
    public interface ICategoryService : IGenericService<CreateCategoryDto, UpdateCategoryDto, ResulCategoryDto>
    {
    }
}
