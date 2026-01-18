namespace InsuranceCodeFirst.DTO.DTOs.ContactDtos;

public record CreateContactDto(string FullName, string Email, string Phone, string Message, string? Status);
