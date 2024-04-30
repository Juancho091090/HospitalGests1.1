

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalGests.Model
{
    public class Treatments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TreatmentId { get; set; }
        public required int MedicalRecordID {  get; set; }
        public required string TreatmentType { get; set; }
        public DateTime? TreatmentStartDate { get; set; }
        public DateTime? TreatmentEndDate { get; set; }
        public required string Dosage { get; set; }
        [ForeignKey("MedicalRecordID")]
        public MedicalRecords? MedicalRecords { get; set; }
    }
}
