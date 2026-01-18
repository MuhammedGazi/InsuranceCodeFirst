using InsuranceCodeFirst.Business.Services.HuggingFaceServices;
using InsuranceCodeFirst.DAL.Repositories.GenericRepositories;
using InsuranceCodeFirst.DAL.UOW;
using InsuranceCodeFirst.DTO.DTOs.ContactDtos;
using InsuranceCodeFirst.Entity.Entities;
using Mapster;
using Microsoft.Extensions.Logging;

namespace InsuranceCodeFirst.Business.Services.ContactServices
{
    public class ContactService(IGenericRepository<Contact> _repository,
                                IUnitOfWork unitOfWork,
                                ILogger<ContactService> _logger,
                                IHuggingFaceService huggingFaceService) : IContactService
    {
        public async Task TCreateAsync(CreateContactDto dto)
        {
            var contact = dto.Adapt<Contact>();
            var aiResult = await huggingFaceService.AnalizEtAsync(dto.Message);
            if (aiResult != null)
            {
                contact.Status = aiResult.Kategori;
            }
            else
            {
                contact.Status = "Değerlendirilmedi";
            }
            await _repository.CreateAsync(contact);
            await unitOfWork.SaveChangeAsync();
            _logger.LogInformation("{Id} numarasına sahip contact oluşturuldu. Durumu: {Status}", contact.ContactId, contact.Status);
        }

        public async Task TDeleteAsync(int id)
        {
            var contact = await _repository.GetByIdAsync(id);
            if (contact is null)
            {
                _logger.LogWarning("{Id} numarasına sahip contact bulunamadı", id);
                throw new Exception("contact bulunamadı");
            }
            _repository.Delete(contact);
            await unitOfWork.SaveChangeAsync();
        }

        public async Task<List<ResultContactDto>> TGetAllAsync()
        {
            _logger.LogInformation("tüm contact listeleniyor");
            var contact = await _repository.GetAllAsync();
            return contact.Adapt<List<ResultContactDto>>();
        }

        public async Task<UpdateContactDto> TGetByIdAsync(int id)
        {
            var contact = await _repository.GetByIdAsync(id);
            if (contact is null)
            {
                _logger.LogWarning("{Id} numarasına sahip contact bulunamadı", id);
                throw new Exception("contact bulunamdı");
            }
            return contact.Adapt<UpdateContactDto>();
        }

        public async Task TUpdateAsync(UpdateContactDto dto)
        {
            var contact = dto.Adapt<Contact>();
            _repository.Update(contact);
            await unitOfWork.SaveChangeAsync();
        }
    }
}
