

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalGests.Model
{
    public class MedicalRecords
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicalRecordId {  get; set; }
        public required int PatientId { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public DateTime? DischargeDate { get; set; }
        public required string DiagnosisPrincipal {  get; set; }
        [ForeignKey("PatientId")]
        public Patients? Patients { get; set; }
    }
}
