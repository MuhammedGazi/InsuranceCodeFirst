namespace InsuranceCodeFirst.DTO.DTOs.ContactDtos;

public record ResultContactDto(int ContactId, string FullName, string Email, string Phone, string Message, string? Status);
