using Kolokwium2.DTO;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkshopController : Controller
{
    private readonly IWorkshopDbService _workshopDbService;

    public WorkshopController(IWorkshopDbService workshopDbService)
    {
        _workshopDbService = workshopDbService;
    }
    
    [HttpGet("getCars/{id}")]
    public async Task<IActionResult> GetMechanics(int id, CancellationToken cancellationToken)
    {
        var car = await _workshopDbService.GetCarAsync(id, cancellationToken);
        return Ok(car);
    }

    [HttpPost("addCar")]
    public async Task<IActionResult> AddCar(CarAddDTO car, CancellationToken cancellationToken = default)
    {
        await _workshopDbService.AddCar(car, cancellationToken);
        return Ok();
    }

}