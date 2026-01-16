using InsuranceCodeFirst.DAL.Repositories.GenericRepositories;
using InsuranceCodeFirst.DAL.UOW;
using InsuranceCodeFirst.DTO.DTOs.FeatureDtos;
using InsuranceCodeFirst.Entity.Entities;
using Mapster;

namespace InsuranceCodeFirst.Business.Services.FeatureServices
{
    public class FeatureService(IGenericRepository<Feature> _repository, IUnitOfWork _unitOfWork) : IFeatureService
    {
        public async Task TCreateAsync(CreateFeatureDto dto)
        {
            var feature = dto.Adapt<Feature>();
            await _repository.CreateAsync(feature);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var feature = await _repository.GetByIdAsync(id);
            if (feature is null)
            {
                throw new Exception("Feature Bulunamadı");
            }
            _repository.Delete(feature);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<ResultFeatureDto>> TGetAllAsync()
        {
            var feature = await _repository.GetAllAsync();
            return feature.Adapt<List<ResultFeatureDto>>();
        }

        public async Task<UpdateFeatureDto> TGetByIdAsync(int id)
        {
            var feature = await _repository.GetByIdAsync(id);
            if (feature is null)
            {
                throw new Exception("Feature Bulunamadı");
            }
            return feature.Adapt<UpdateFeatureDto>();
        }

        public async Task TUpdateAsync(UpdateFeatureDto dto)
        {
            var feature = dto.Adapt<Feature>();
            _repository.Update(feature);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
