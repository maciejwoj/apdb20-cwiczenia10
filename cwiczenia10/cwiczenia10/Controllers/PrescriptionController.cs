using Microsoft.AspNetCore.Mvc;
using cwiczenia10.Dtos;
using cwiczenia10.Services;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    private readonly IDbService _dbService;
    
    public PrescriptionController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> AddNewPrescription(NewPrescritionDTO newPrescription)
    {
        if (newPrescription.PrescriptionMedicamentDTOs.Count < 10 && (newPrescription.DueDate >= newPrescription.Date))
        {
            try
            {
                await _dbService.AddNewPrescription(newPrescription);
                return Created("api/prescriptions", newPrescription);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }
        return BadRequest("Invalid data");
    }
}