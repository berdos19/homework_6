using DriversManagement.API.DTOs;
using DriversManagement.API.Models;

namespace DriversManagement.API.Interfaces;

public interface IDriverService
{
    Task<ICollection<Driver>> GetAllDrivers(int skip, int take);
    Task<Driver?> GetDriverById(int id);
    Task<ICollection<Driver>> SearchDrivers(string searchTerm);
    Task<Driver> AddDriver(DriverDTO driverDto);
    Task<bool> UpdateDriverName(int id, string newName);
    Task<bool> UpdateDriver(int id, DriverDTO driverDto);
    Task<bool> DeleteDriver(int id);
}