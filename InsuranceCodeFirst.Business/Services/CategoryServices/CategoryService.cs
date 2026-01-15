using InsuranceCodeFirst.DAL.Repositories.GenericRepositories;
using InsuranceCodeFirst.DAL.UOW;
using InsuranceCodeFirst.DTO.DTOs.CategoryDtos;
using InsuranceCodeFirst.Entity.Entities;
using Mapster;

namespace InsuranceCodeFirst.Business.Services.CategoryServices
{
    public class CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork) : ICategoryService
    {
        public async Task TCreateAsync(CreateCategoryDto dto)
        {
            var category = dto.Adapt<Category>();
            await repository.CreateAsync(category);
            await unitOfWork.SaveChangeAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var category = await repository.GetByIdAsync(id);
            if (category is null)
            {
                throw new Exception("kategori bulunamadı");
            }
            repository.Delete(category);
            await unitOfWork.SaveChangeAsync();
        }

        public async Task<List<ResulCategoryDto>> TGetAllAsync()
        {
            var category = await repository.GetAllAsync();
            return category.Adapt<List<ResulCategoryDto>>();
        }

        public async Task<UpdateCategoryDto> TGetByIdAsync(int id)
        {
            var category = await repository.GetByIdAsync(id);
            if (category is null)
            {
                throw new Exception("Kategori bulunamadı");
            }
            return category.Adapt<UpdateCategoryDto>();
        }

        public async Task TUpdateAsync(UpdateCategoryDto dto)
        {
            var category = dto.Adapt<Category>();
            repository.Update(category);
            await unitOfWork.SaveChangeAsync();
        }
    }
}
