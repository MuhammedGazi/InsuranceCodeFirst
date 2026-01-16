using InsuranceCodeFirst.DAL.Repositories.GenericRepositories;
using InsuranceCodeFirst.DAL.UOW;
using InsuranceCodeFirst.DTO.DTOs.BannerDtos;
using InsuranceCodeFirst.Entity.Entities;
using Mapster;

namespace InsuranceCodeFirst.Business.Services.BannerServices
{
    public class BannerService(IGenericRepository<Banner> _repository, IUnitOfWork _unitOfWork) : IBannerService
    {
        public async Task TCreateAsync(CreateBannerDto dto)
        {
            var banner = dto.Adapt<Banner>();
            await _repository.CreateAsync(banner);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var banner = await _repository.GetByIdAsync(id);
            if (banner is null)
            {
                throw new Exception("Banner Bulunamadı");
            }
            _repository.Delete(banner);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<ResultBannerDto>> TGetAllAsync()
        {
            var banner = await _repository.GetAllAsync();
            return banner.Adapt<List<ResultBannerDto>>();
        }

        public async Task<UpdateBannerDto> TGetByIdAsync(int id)
        {
            var banner = await _repository.GetByIdAsync(id);
            if (banner is null)
            {
                throw new Exception("Banner Bulunamadı");
            }
            return banner.Adapt<UpdateBannerDto>();
        }

        public async Task TUpdateAsync(UpdateBannerDto dto)
        {
            var banner = dto.Adapt<Banner>();
            _repository.Update(banner);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
