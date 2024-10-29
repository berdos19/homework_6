using DriversManagement.API.Models;

namespace DriversManagement.API.Interfaces;

public interface IDriverService
{
    Task<ICollection<Driver>> GetAllDrivers(int skip, int take);
}