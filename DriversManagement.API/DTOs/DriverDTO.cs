namespace DriversManagement.API.DTOs;

public class DriverDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Category { get; set; }
    public int Salary { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? LicenceNumber { get; set; }
}