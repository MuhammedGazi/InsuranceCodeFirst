using InsuranceCodeFirst.DAL.Repositories.GenericRepositories;
using InsuranceCodeFirst.DAL.UOW;
using InsuranceCodeFirst.DTO.DTOs.PolicyDtos;
using InsuranceCodeFirst.Entity.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace InsuranceCodeFirst.Business.Services.PolicyServices
{
    public class PolicyService(IGenericRepository<Policy> _repository, IUnitOfWork _unitOfWork) : IPolicyService
    {
        public async Task TCreateAsync(CreatePolicyDto dto)
        {
            var policy = dto.Adapt<Policy>();
            await _repository.CreateAsync(policy);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var policy = await _repository.GetByIdAsync(id);
            if (policy is null)
            {
                throw new Exception("Policy Bulunamadı");
            }
            _repository.Delete(policy);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<ResultPolicyDto>> TGetAllAsync()
        {
            var queryable = _repository.GetQueryable();
            var policy = await queryable.Include(x => x.Customer).Include(y => y.InsurancePackage).ToListAsync();
            return policy.Adapt<List<ResultPolicyDto>>();
        }

        public async Task<UpdatePolicyDto> TGetByIdAsync(int id)
        {
            var policy = await _repository.GetByIdAsync(id);
            if (policy is null)
            {
                throw new Exception("Policy Bulunamadı");
            }
            return policy.Adapt<UpdatePolicyDto>();
        }

        public async Task TUpdateAsync(UpdatePolicyDto dto)
        {
            var policy = dto.Adapt<Policy>();
            _repository.Update(policy);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
