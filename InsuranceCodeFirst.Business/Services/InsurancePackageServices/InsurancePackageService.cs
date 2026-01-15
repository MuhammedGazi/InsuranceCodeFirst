using InsuranceCodeFirst.DAL.Repositories.GenericRepositories;
using InsuranceCodeFirst.DAL.UOW;
using InsuranceCodeFirst.DTO.DTOs.InsuranceDtos;
using InsuranceCodeFirst.Entity.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace InsuranceCodeFirst.Business.Services.InsurancePackageServices
{
    public class InsurancePackageService(IGenericRepository<InsurancePackage> repository, IUnitOfWork unitOfWork) : IInsurancePackageService
    {
        public async Task TCreateAsync(CreateInsurancePackageDto dto)
        {
            var package = dto.Adapt<InsurancePackage>();
            await repository.CreateAsync(package);
            await unitOfWork.SaveChangeAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var package=await repository.GetByIdAsync(id);
            if(package is null)
            {
                throw new Exception("InsurancePackage bulunamadı");
            }
            repository.Delete(package);
            await unitOfWork.SaveChangeAsync();
        }

        public async Task<List<ResultInsurancePackageDto>> TGetAllAsync()
        {
            var queryable = repository.GetQueryable();
            var packages = await queryable.Include(x => x.Category).ToListAsync();
            return packages.Adapt<List<ResultInsurancePackageDto>>();
        }

        public async Task<UpdateInsurancePackageDto> TGetByIdAsync(int id)
        {
            var package = await repository.GetByIdAsync(id);
            if(package is null)
            {
                throw new Exception("InsurancePackage bulunamadı");
            }
            return package.Adapt<UpdateInsurancePackageDto>();
        }

        public async Task TUpdateAsync(UpdateInsurancePackageDto dto)
        {
            var package = dto.Adapt<InsurancePackage>();
            repository.Update(package);
            await unitOfWork.SaveChangeAsync();
        }
    }
}
