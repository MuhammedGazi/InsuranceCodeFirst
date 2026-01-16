using InsuranceCodeFirst.DAL.Repositories.GenericRepositories;
using InsuranceCodeFirst.DAL.UOW;
using InsuranceCodeFirst.DTO.DTOs.ServiceDtos;
using InsuranceCodeFirst.Entity.Entities;
using Mapster;

namespace InsuranceCodeFirst.Business.Services.ServiceServices
{
    public class ServiceService(IGenericRepository<Service> _repository, IUnitOfWork _unitOfWork) : IServiceService
    {
        public async Task TCreateAsync(CreateServiceDto dto)
        {
            var service = dto.Adapt<Service>();
            await _repository.CreateAsync(service);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var service = await _repository.GetByIdAsync(id);
            if (service is null)
            {
                throw new Exception("Service Bulunamadı");
            }
            _repository.Delete(service);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<ResultServiceDto>> TGetAllAsync()
        {
            var service = await _repository.GetAllAsync();
            return service.Adapt<List<ResultServiceDto>>();
        }

        public async Task<UpdateServiceDto> TGetByIdAsync(int id)
        {
            var service = await _repository.GetByIdAsync(id);
            if (service is null)
            {
                throw new Exception("Service Bulunamadı");
            }
            return service.Adapt<UpdateServiceDto>();
        }

        public async Task TUpdateAsync(UpdateServiceDto dto)
        {
            var service = dto.Adapt<Service>();
            _repository.Update(service);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
