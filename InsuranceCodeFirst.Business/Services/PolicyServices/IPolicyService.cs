using InsuranceCodeFirst.DTO.DTOs.PolicyDtos;

namespace InsuranceCodeFirst.Business.Services.PolicyServices
{
    public interface IPolicyService : IGenericService<CreatePolicyDto, UpdatePolicyDto, ResultPolicyDto>
    {
    }
}
