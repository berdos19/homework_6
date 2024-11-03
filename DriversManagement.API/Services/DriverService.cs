using DriversManagement.API.DTOs;
using DriversManagement.API.Interfaces;
using DriversManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DriversManagement.API.Services;

public class DriverService : IDriverService
{
    private readonly IRepository _repository;

    public DriverService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<Driver>> GetAllDrivers(int skip, int take)
    {
        return await _repository.GetAll<Driver>()
            .Skip(skip)
            .Take(take)
            .ToArrayAsync();
    }
    public async Task<Driver?> GetDriverById(int id)
    {
        return await _repository.GetAll<Driver>().FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<ICollection<Driver>> SearchDrivers(string searchTerm)
    {
        return await _repository.GetAll<Driver>()
            .Where(d => d.FirstName.Contains(searchTerm) || d.LastName.Contains(searchTerm))
            .ToArrayAsync();
    }

    public async Task<Driver> AddDriver(DriverDTO driverDto)
    {
        var driver = new Driver
        {
            FirstName = driverDto.FirstName,
            LastName = driverDto.LastName,
            Category = driverDto.Category,
            Salary = driverDto.Salary,
            DateOfBirth = driverDto.DateOfBirth,
            LicenceNumber = driverDto.LicenceNumber
        };

        await _repository.Add(driver);
        return driver;
    }

    public async Task<bool> UpdateDriverName(int id, string newName)
    {
        var driver = await GetDriverById(id);
        if (driver == null) return false;

        driver.FirstName = newName;
        await _repository.Update(driver); 
        return true;
    }

    public async Task<bool> UpdateDriver(int id, DriverDTO driverDto)
    {
        var driver = await GetDriverById(id);
        if (driver == null) return false;

        driver.FirstName = driverDto.FirstName;
        driver.LastName = driverDto.LastName;
        driver.Category = driverDto.Category;
        driver.Salary = driverDto.Salary;
        driver.DateOfBirth = driverDto.DateOfBirth;
        driver.LicenceNumber = driverDto.LicenceNumber;

        await _repository.Update(driver); 
        return true;
    }

    public async Task<bool> DeleteDriver(int id)
    {
        var driver = await GetDriverById(id);
        if (driver == null) return false;

        await _repository.Delete(driver); 
        return true;
    }
}