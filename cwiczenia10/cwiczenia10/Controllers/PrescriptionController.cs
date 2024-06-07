using cwiczenia10.Context;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenia10.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    private readonly ApdbContext _dbContext;
    
    public PrescriptionController(ApdbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult GetPrescription()
    {
        
        return Ok();
    }
}