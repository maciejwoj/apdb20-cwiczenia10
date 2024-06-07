using cwiczenia10.Models;
using Microsoft.EntityFrameworkCore;

namespace cwiczenia10.Context;

public class ApdbContext : DbContext
{
    protected ApdbContext()
    {
    }

    public ApdbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
}