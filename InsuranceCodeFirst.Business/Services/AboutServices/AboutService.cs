using InsuranceCodeFirst.DAL.Repositories.GenericRepositories;
using InsuranceCodeFirst.DAL.UOW;
using InsuranceCodeFirst.DTO.DTOs.AboutDtos;
using InsuranceCodeFirst.Entity.Entities;
using Mapster;
using Microsoft.Extensions.Logging;

namespace InsuranceCodeFirst.Business.Services.AboutServices
{
    public class AboutService(IGenericRepository<About> _repository, IUnitOfWork _unitOfWork,
                              ILogger<AboutService> _logger) : IAboutService
    {
        public async Task TCreateAsync(CreateAboutDto dto)
        {
            var about = dto.Adapt<About>();
            await _repository.CreateAsync(about);
            await _unitOfWork.SaveChangeAsync();

            _logger.LogInformation("Kayıt Başarıyla oluşturuldu. ID: {Id}", about.AboutId);
        }

        public async Task TDeleteAsync(int id)
        {
            var about = await _repository.GetByIdAsync(id);
            if (about is null)
            {
                _logger.LogWarning("{Id} numaralı 'Hakkımızda' kaydı silinmek istendi ama bulunamadı", id);
                throw new Exception("About Bulunamadı");
            }
            _repository.Delete(about);
            await _unitOfWork.SaveChangeAsync();
            _logger.LogInformation("{Id} numaralı kayıt başarıyla silindi.", id);
        }

        public async Task<List<ResultAboutDto>> TGetAllAsync()
        {
            _logger.LogInformation("Tüm 'Hakkımızda' verileri listeleniyor");
            var about = await _repository.GetAllAsync();
            return about.Adapt<List<ResultAboutDto>>();
        }

        public async Task<UpdateAboutDto> TGetByIdAsync(int id)
        {
            var about = await _repository.GetByIdAsync(id);
            if (about is null)
            {
                _logger.LogWarning("GetById hatası: {Id} numaralı kayıt mevcut değil.", id);
                throw new Exception("About Bulunamadı");
            }
            return about.Adapt<UpdateAboutDto>();
        }

        public async Task TUpdateAsync(UpdateAboutDto dto)
        {
            _logger.LogInformation("ID: {Id} olan kayıt güncelleniyor.", dto.AboutId);
            var about = dto.Adapt<About>();
            _repository.Update(about);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
