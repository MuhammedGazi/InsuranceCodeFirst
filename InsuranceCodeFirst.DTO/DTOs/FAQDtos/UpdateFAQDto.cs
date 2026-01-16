namespace InsuranceCodeFirst.DTO.DTOs.FAQDtos;

public record UpdateFAQDto
{
    public int FAQId { get; init; }
    public string Question { get; init; }
    public string Answer { get; init; }
}