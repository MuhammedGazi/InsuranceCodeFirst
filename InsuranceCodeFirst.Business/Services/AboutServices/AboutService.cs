using InsuranceCodeFirst.DAL.Repositories.GenericRepositories;
using InsuranceCodeFirst.DAL.UOW;
using InsuranceCodeFirst.DTO.DTOs.AboutDtos;
using InsuranceCodeFirst.Entity.Entities;
using Mapster;

namespace InsuranceCodeFirst.Business.Services.AboutServices
{
    public class AboutService(IGenericRepository<About> _repository, IUnitOfWork _unitOfWork) : IAboutService
    {
        public async Task TCreateAsync(CreateAboutDto dto)
        {
            var category = dto.Adapt<About>();
            await _repository.CreateAsync(category);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category is null)
            {
                throw new Exception("About Bulunamadı");
            }
            _repository.Delete(category);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<ResultAboutDto>> TGetAllAsync()
        {
            var category = await _repository.GetAllAsync();
            return category.Adapt<List<ResultAboutDto>>();
        }

        public async Task<UpdateAboutDto> TGetByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category is null)
            {
                throw new Exception("About Bulunamadı");
            }
            return category.Adapt<UpdateAboutDto>();
        }

        public async Task TUpdateAsync(UpdateAboutDto dto)
        {
            var category = dto.Adapt<About>();
            _repository.Update(category);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
