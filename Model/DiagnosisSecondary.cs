

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalGests.Model
{
    public class DiagnosisSecondary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiagnosisId { get; set; }
        public required string DiagnosisName { get; set; }
        public string? DiagnosisDescription { get; set; }
        public string? DiagnosisType { get; set; }
        public int MedicalRecordId { get; set; }
        [ForeignKey("MedicalRecordId")]
        public MedicalRecords? MedicalRecords { get; set; }
    }
}
