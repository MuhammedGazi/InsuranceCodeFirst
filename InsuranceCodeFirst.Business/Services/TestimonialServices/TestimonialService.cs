using InsuranceCodeFirst.DAL.Repositories.GenericRepositories;
using InsuranceCodeFirst.DAL.UOW;
using InsuranceCodeFirst.DTO.DTOs.TestimonialDtos;
using InsuranceCodeFirst.Entity.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace InsuranceCodeFirst.Business.Services.TestimonialServices
{
    public class TestimonialService(IGenericRepository<Testimonial> _repository, IUnitOfWork _unitOfWork) : ITestimonialService
    {
        public async Task TCreateAsync(CreateTestimonialDto dto)
        {
            var testimonial = dto.Adapt<Testimonial>();
            await _repository.CreateAsync(testimonial);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var testimonial = await _repository.GetByIdAsync(id);
            if (testimonial != null)
            {
                throw new Exception("Testimonial Bulunamadı");
            }
            _repository.Delete(testimonial);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<ResultTestimonialDto>> TGetAllAsync()
        {
            var quareble = _repository.GetQueryable();
            var testimonial = await quareble.Include(x => x.Customer).ToListAsync();
            return testimonial.Adapt<List<ResultTestimonialDto>>();
        }

        public async Task<UpdateTestimonialDto> TGetByIdAsync(int id)
        {
            var testimonial = await _repository.GetByIdAsync(id);
            if (testimonial is null)
            {
                throw new Exception("Testimonial Bulunamadı");
            }
            return testimonial.Adapt<UpdateTestimonialDto>();
        }

        public async Task TUpdateAsync(UpdateTestimonialDto dto)
        {
            var testimonial = dto.Adapt<Testimonial>();
            _repository.Update(testimonial);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
