using InsuranceCodeFirst.DTO.DTOs.CustomerDtos;

namespace InsuranceCodeFirst.DTO.DTOs.TestimonialDtos;

public record ResultTestimonialDto(int TestimonialId, int starCount, string Description, int CustomerId, ResultCustomerDto Customer);