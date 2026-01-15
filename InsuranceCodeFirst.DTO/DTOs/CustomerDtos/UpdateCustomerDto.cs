namespace InsuranceCodeFirst.DTO.DTOs.CustomerDtos;
public record UpdateCustomerDto(int CustomerId, string FirstName, string LastName, string Email, string Phone, string City);
