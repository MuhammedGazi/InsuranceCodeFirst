using InsuranceCodeFirst.DAL.Repositories.GenericRepositories;
using InsuranceCodeFirst.DAL.UOW;
using InsuranceCodeFirst.DTO.DTOs.FAQDtos;
using InsuranceCodeFirst.Entity.Entities;
using Mapster;

namespace InsuranceCodeFirst.Business.Services.FAQServices
{
    public class FAQService(IGenericRepository<FAQ> _repository, IUnitOfWork _unitOfWork) : IFAQService
    {
        public async Task TCreateAsync(CreateFAQDto dto)
        {
            var faq = dto.Adapt<FAQ>();
            await _repository.CreateAsync(faq);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category is null)
            {
                throw new Exception("FAQ Bulunamadı");
            }
            _repository.Delete(category);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<ResultFAQDto>> TGetAllAsync()
        {
            var faq = await _repository.GetAllAsync();
            return faq.Adapt<List<ResultFAQDto>>();
        }

        public async Task<UpdateFAQDto> TGetByIdAsync(int id)
        {
            var faq = await _repository.GetByIdAsync(id);
            if (faq is null)
            {
                throw new Exception("FAQ Bulunamadı");
            }
            return faq.Adapt<UpdateFAQDto>();
        }

        public async Task TUpdateAsync(UpdateFAQDto dto)
        {
            var faq = dto.Adapt<FAQ>();
            _repository.Update(faq);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
