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
}

/*

_context.Drivers = IQueryable<Driver> = generate SQL script

LINQ to SQL
_context.Drivers.Where(d => d.LastName == "Test"); = SQL: select * from [Drivers] where LastName = 'Test'


var list = _context.Drivers.Where(d => d.Id == 3).Select(d => d.FirstName);
SQL: select d.FirstName from [Drivers] d where d.Id = 3;
list = list.Where(d => d.FirstName.Contains("A"));
SQL: select d.FirstName from [Drivers] d where d.Id = 3 and d.FirstName like '%A%';

list.ToList()              -> execute SQL script
    .ToArray()
    .ToDictionary()














*/