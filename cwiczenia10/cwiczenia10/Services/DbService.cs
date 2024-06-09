using cwiczenia10.Context;
using cwiczenia10.Dtos;
using cwiczenia10.Models;
using cwiczenia10.Services;
using Microsoft.EntityFrameworkCore;

public class DbService : IDbService
{
    private readonly ApdbContext _context;

    public DbService(ApdbContext context)
    {
        _context = context;
    }

    public async Task<PatientDto?> GetPatient(int patientID)
    {
        return await _context.Patients
            .Include(p => p.Prescriptions)
            .ThenInclude(p => p.Doctor)
            .Include(p => p.Prescriptions)
            .ThenInclude(p => p.PrescriptionMedicaments)
            .ThenInclude(pm => pm.Medicaments)
            .Where(p => p.IdPatient == patientID)
            .Select(p => new PatientDto
            {
                IdPatient = p.IdPatient,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Birthdate = p.Birthdate,
                Prescriptions = p.Prescriptions.Select(pr => new PrescriptionDto
                {
                    IdPrescription = pr.IdPrescription,
                    Date = pr.Date,
                    DueDate = pr.DueDate,
                    Doctor = new DoctorDto
                    {
                        IdDoctor = pr.Doctor.IdDoctor,
                        FirstName = pr.Doctor.FirstName,
                        LastName = pr.Doctor.LastName
                    },
                    Medicaments = pr.PrescriptionMedicaments.Select(pm => new MedicamentDto
                    {
                        IdMedicament = pm.Medicaments.IdMedicament,
                        Name = pm.Medicaments.Name,
                        Dose = pm.Dose,
                        Description = pm.Medicaments.Description
                    }).ToList()
                }).OrderBy(pr => pr.DueDate).ToList()
            }).FirstOrDefaultAsync();
    }

    public async Task AddNewPrescription(NewPrescritionDTO newPrescrition)
    {
        var patient = await _context.Patients.FindAsync(newPrescrition.newPatient.IdPatient);
        if (patient == null)
        {
            patient = new Patient
            {
                IdPatient = newPrescrition.newPatient.IdPatient,
                FirstName = newPrescrition.newPatient.FirstName,
                LastName = newPrescrition.newPatient.LastName,
                Birthdate = newPrescrition.newPatient.Birthdate
            };
            _context.Patients.Add(patient);
        }

        var prescription = new Prescription
        {
            Date = newPrescrition.Date,
            DueDate = newPrescrition.DueDate,
            Patient = patient,
            PrescriptionMedicaments = newPrescrition.PrescriptionMedicamentDTOs.Select(m => new PrescriptionMedicament
            {
                IdMedicament = m.IdMedicament,
                Dose = m.Dose,
                Details = m.Details
            }).ToList()
        };

        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();
    }
}

        
    
