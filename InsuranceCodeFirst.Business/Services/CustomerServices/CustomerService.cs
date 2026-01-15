using InsuranceCodeFirst.DAL.Repositories.GenericRepositories;
using InsuranceCodeFirst.DAL.UOW;
using InsuranceCodeFirst.DTO.DTOs.CustomerDtos;
using InsuranceCodeFirst.Entity.Entities;
using Mapster;

namespace InsuranceCodeFirst.Business.Services.CustomerServices
{
    public class CustomerService(IGenericRepository<Customer> repository, IUnitOfWork unitOfWork) : ICustomerService
    {
        public async Task TCreateAsync(CreateCustomerDto dto)
        {
            var customert = dto.Adapt<Customer>();
            await repository.CreateAsync(customert);
            await unitOfWork.SaveChangeAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var category = await repository.GetByIdAsync(id);
            if (category is null)
            {
                throw new Exception("Customer bulunamadı");
            }
            repository.Delete(category);
            await unitOfWork.SaveChangeAsync();
        }

        public async Task<List<ResultCustomerDto>> TGetAllAsync()
        {
            var category = await repository.GetAllAsync();
            return category.Adapt<List<ResultCustomerDto>>();
        }

        public async Task<UpdateCustomerDto> TGetByIdAsync(int id)
        {
            var category = await repository.GetByIdAsync(id);
            if (category is null)
            {
                throw new Exception("Customer bulunamadı");
            }
            return category.Adapt<UpdateCustomerDto>();
        }

        public async Task TUpdateAsync(UpdateCustomerDto dto)
        {
            var customer = dto.Adapt<Customer>();
            repository.Update(customer);
            await unitOfWork.SaveChangeAsync();
        }
    }
}
