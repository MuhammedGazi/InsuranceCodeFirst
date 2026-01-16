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
            var about = dto.Adapt<About>();
            await _repository.CreateAsync(about);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var about = await _repository.GetByIdAsync(id);
            if (about is null)
            {
                throw new Exception("About Bulunamadı");
            }
            _repository.Delete(about);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<ResultAboutDto>> TGetAllAsync()
        {
            var about = await _repository.GetAllAsync();
            return about.Adapt<List<ResultAboutDto>>();
        }

        public async Task<UpdateAboutDto> TGetByIdAsync(int id)
        {
            var about = await _repository.GetByIdAsync(id);
            if (about is null)
            {
                throw new Exception("About Bulunamadı");
            }
            return about.Adapt<UpdateAboutDto>();
        }

        public async Task TUpdateAsync(UpdateAboutDto dto)
        {
            var about = dto.Adapt<About>();
            _repository.Update(about);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
