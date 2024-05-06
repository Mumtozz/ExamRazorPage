namespace Domain.DTOs.CustomerDTOs;

public class GetCustomerDto
{
    
    public int Id { get; set; }
    public string? CustomerName { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
}
