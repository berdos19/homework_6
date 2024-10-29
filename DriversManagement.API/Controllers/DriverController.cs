using DriversManagement.API.DTOs;
using DriversManagement.API.Interfaces;
using DriversManagement.API.Models;
using Microsoft.AspNetCore.Mvc;

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

    [HttpPost]
    public ActionResult AddDriver(DriverDTO driver)
    {
        return Ok();
    }
}