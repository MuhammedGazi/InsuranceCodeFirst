using InsuranceCodeFirst.DTO.DTOs.CustomerDtos;

namespace InsuranceCodeFirst.Business.Services.CustomerServices
{
    public interface ICustomerService : IGenericService<CreateCustomerDto, UpdateCustomerDto, ResultCustomerDto>
    {
    }
}
