using System.ComponentModel.DataAnnotations;

namespace cwiczenia10.Dtos;

public class NewPrescritionDTO
{
    [Required]
    public NewPatientDTO newPatient { get; set; } = null!;
    [Required]
    public ICollection<PrescriptionMedicamentDTO> PrescriptionMedicamentDTOs { get; set; } = new List<PrescriptionMedicamentDTO>();
    [Required]
    public DateOnly Date { get; set; }
    [Required]
    public DateOnly DueDate { get; set; }
}

public class NewPatientDTO
{
    [Required]
    public int IdPatient { get; set; }
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    [Required]
    public DateOnly Birthdate { get; set; }
}

public class PrescriptionMedicamentDTO
{
    public int IdMedicament { get; set; }
    public int? Dose { get; set; }
    [MaxLength(100)]
    public string Details { get; set; }
}