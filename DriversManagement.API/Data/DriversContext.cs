using DriversManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DriversManagement.API.Data;

public class MariaDbContext : DbContext
{
    public MariaDbContext(DbContextOptions<MariaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Driver> Drivers { get; set; } 
}