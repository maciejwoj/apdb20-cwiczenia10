using cwiczenia10.Services;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenia10.Controllers;

public class ClientController: ControllerBase
{
    private readonly IDbService _dbService;
    
    public ClientController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatient(int patientId)
    {
        try
        {
            var patient = await _dbService.GetPatient(patientId);
            return Ok(patient);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
    
    
}