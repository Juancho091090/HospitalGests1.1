using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalGests.Model
{
    public class Medicines
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicineId { get; set; }
        public required string MedicineName { get; set; }
        public required float QuantityAvaiable { get; set; }
        public DateTime? DueDate { get; set; }
        public int TreatmentId { get; set; }
        [ForeignKey("TreatmentId")]
        public Treatments? Treatment { get; set; }
        public int IdPrescription {  get; set; }
        public Prescriptions? Prescriptions { get; set; }
    }
}