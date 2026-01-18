using InsuranceCodeFirst.DTO.DTOs.ContactDtos;

namespace InsuranceCodeFirst.Business.Services.ContactServices
{
    public interface IContactService : IGenericService<CreateContactDto, UpdateContactDto, ResultContactDto>
    {
    }
}
