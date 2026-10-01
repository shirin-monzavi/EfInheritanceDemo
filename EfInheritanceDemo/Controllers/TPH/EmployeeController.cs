using EfInheritanceDemo.Data;
using EfInheritanceDemo.Models;
using EfInheritanceDemo.Models.TPH;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfInheritanceDemo.Controllers.TPH;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly AppDbContext _db;

    public EmployeesController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet("employees")]
    public async Task<IActionResult> GetEmployees()
    {
        var employees = await _db.Employees.ToListAsync();

        return Ok(employees);
    }

    [HttpGet("developers")]
    public async Task<IActionResult> GetDevelopers()
    {
        var developers = await _db.Developers.ToListAsync();

        return Ok(developers);
    }

    [HttpGet("managers")]
    public async Task<IActionResult> GetManagers()
    {
        var managers = await _db.Managers.ToListAsync();

        return Ok(managers);
    }

    [HttpGet("designers")]
    public async Task<IActionResult> GetDesigners()
    {
        var designers = await _db.Designers.ToListAsync();

        return Ok(designers);
    }

    [HttpPost("seed")]
    public async Task<IActionResult> Seed()
    {
        var employees = new Employee[]
        {
        new Developer
        {
            Name = "Ali",
            Salary = 1000,
            ProgrammingLanguage = "C#"
        },
        new Developer
        {
            Name = "Sara",
            Salary = 1200,
            ProgrammingLanguage = "Java"
        },
        new Manager
        {
            Name = "Reza",
            Salary = 1800,
            TeamSize = 8
        },
        new Designer
        {
            Name = "Mina",
            Salary = 1100,
            DesignTool = "Figma"
        }
        };

        await _db.Employees.AddRangeAsync(employees);
        await _db.SaveChangesAsync();

        return Ok();
    }
}
