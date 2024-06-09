using cwiczenia10.Dtos;
using cwiczenia10.Models;

namespace cwiczenia10.Services;

public interface IDbService
{
    Task<PatientDto?> GetPatient(int patientID);
    Task AddNewPrescription(NewPrescritionDTO newPrescrition);
}