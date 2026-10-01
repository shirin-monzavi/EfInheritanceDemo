using EfInheritanceDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfInheritanceDemo.Controllers.TPT;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly AppDbContext _db;

    public VehiclesController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllVehicles()
    {
        var vehicles = await _db.Vehicles.ToListAsync();

        return Ok(vehicles);
    }

    [HttpGet("cars")]
    public async Task<IActionResult> GetCars()
    {
        var cars = await _db.Cars.ToListAsync();

        return Ok(cars);
    }

    [HttpGet("electric-cars")]
    public async Task<IActionResult> GetElectricCars()
    {
        var cars = await _db.ElectricCars.ToListAsync();

        return Ok(cars);
    }
}