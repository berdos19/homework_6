using DriversManagement.API.DTOs;
using DriversManagement.API.Interfaces;
using DriversManagement.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DriversManagement.API.Controllers;

[ApiController]
[Route("drivers")]
public class DriverController : ControllerBase
{
    private readonly IDriverService _driverService;

    public DriverController(IDriverService driverService)
    {
        _driverService = driverService;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<Driver>>> GetDrivers(
        [FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return Ok(await _driverService.GetAllDrivers(skip, take));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Driver?>> GetDriverById(int id)
    {
        return Ok(await _driverService.GetDriverById(id));
    }

    [HttpGet("search/{searchTerm}")]
    public async Task<ActionResult<ICollection<Driver>>> SearchDrivers(string searchTerm)
    {
        return Ok(await _driverService.SearchDrivers(searchTerm));
    }

    [HttpPost]
    public async Task<ActionResult<Driver>> AddDriver(DriverDTO driver)
    {
        return Ok(await _driverService.AddDriver(driver));
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<bool>> UpdateDriverName(int id, [FromBody] string newName)
    {
        return Ok(await _driverService.UpdateDriverName(id, newName));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> UpdateDriver(int id, DriverDTO driver)
    {
        return Ok(await _driverService.UpdateDriver(id, driver));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteDriver(int id)
    {
        return Ok(await _driverService.DeleteDriver(id));
    }
}