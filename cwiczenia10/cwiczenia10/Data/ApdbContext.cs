using System.Reflection.Metadata.Ecma335;
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

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Doctor>().HasData(new List<Doctor>
    {
        new Doctor
        {
            IdDoctor = 1,
            FirstName = "Jan",
            LastName = "Kowalski",
            Email = "jankowalski@gmail.com"
        },
        new Doctor
        {
            IdDoctor = 2,
            FirstName = "Marek",
            LastName = "Nowowalski",
            Email = "nowakowalski@gmail.com"
        }
    });

    modelBuilder.Entity<Medicament>().HasData(new List<Medicament>
    {
        new Medicament
        {
            IdMedicament = 1,
            Name = "apap",
            Description = "cosam m,,..,",
            Type = "fever"
        },
        new Medicament
        {
            IdMedicament = 2,
            Name = "fgdhjnp",
            Description = "cosdftm m,,..,",
            Type = "fer"
        }
    });

    modelBuilder.Entity<Patient>().HasData(new List<Patient>
    {
        new Patient
        {
            IdPatient = 1,
            FirstName = "olek",
            LastName = "kowal",
            Birthdate = DateOnly.Parse("2001-06-01")
        },
        new Patient
        {
            IdPatient = 2,
            FirstName = "Alek",
            LastName = "Mokwowal",
            Birthdate = DateOnly.Parse("2000-06-08")
        }
    });

    modelBuilder.Entity<Prescription>().HasData(new List<Prescription>
    {
        new Prescription
        {
            IdPrescription = 1,
            Date = DateOnly.Parse("2024-05-28"),
            DueDate = DateOnly.Parse("2024-06-28"),
            IdPatient = 1,
            IdDoctor = 1
        },
        new Prescription
        {
            IdPrescription = 2,
            Date = DateOnly.Parse("2024-05-29"),
            DueDate = DateOnly.Parse("2024-06-29"),
            IdPatient = 2,
            IdDoctor = 2
        }
    });

    modelBuilder.Entity<PrescriptionMedicament>().HasData(new List<PrescriptionMedicament>
    {
        new PrescriptionMedicament
        {
            IdPrescription = 1,
            IdMedicament = 1,
            Dose = 1,
            Details = "Take once a day after meal."
        },
        new PrescriptionMedicament
        {
            IdPrescription = 2,
            IdMedicament = 2,
            Dose = 2,
            Details = "Take twice a day before meal."
        }
    });
}

    
}