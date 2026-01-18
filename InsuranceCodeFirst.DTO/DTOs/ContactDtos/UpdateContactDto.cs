namespace InsuranceCodeFirst.DTO.DTOs.ContactDtos;

public record UpdateContactDto(int ContactId, string FullName, string Email, string Phone, string Message, string? Status);
