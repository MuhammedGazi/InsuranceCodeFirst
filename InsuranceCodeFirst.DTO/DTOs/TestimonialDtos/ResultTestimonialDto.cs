using InsuranceCodeFirst.DTO.DTOs.CustomerDtos;

namespace InsuranceCodeFirst.DTO.DTOs.TestimonialDtos;

public record ResultTestimonialDto(int TestimonialId, int StarCount, string Description, int CustomerId, ResultCustomerDto Customer);