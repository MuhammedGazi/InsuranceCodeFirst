namespace InsuranceCodeFirst.DTO.DTOs.FAQDtos;

public record CreateFAQDto
{
    public string Question { get; init; }
    public string Answer { get; init; }
}