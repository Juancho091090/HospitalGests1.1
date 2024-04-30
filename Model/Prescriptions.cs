

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalGests.Model
{
    public class Prescriptions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPrescription { get; set; }
        public int MedicalRecordId { get; set; }
        public required string Dose { get; set; }
        public required string Duration { get; set; }
        public DateOnly Dateissue { get; set; }
        public required string State { get; set; }
        [ForeignKey("MedicalRecordId")]
        public MedicalRecords? MedicalRecords { get; set; }
        public int MedicineId { get; set; }
        public Medicines? Medicines { get; set; }

    }
}
