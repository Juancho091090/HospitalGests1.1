

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalGests.Model
{
    public class ExamResults
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExamId { get; set; }
        public required int MedicalRecordId { get; set; }
        public required string ExamType { get; set; }
        public DateTime? ExamDate { get; set; }
        public required string Results {  get; set; }
        public string? Observations { get; set; }
        [ForeignKey("MedicalRecordId")]
        public MedicalRecords? MedicalRecords { get; set; }
    }
}
