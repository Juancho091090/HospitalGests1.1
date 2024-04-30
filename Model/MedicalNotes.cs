

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalGests.Model
{
    public class MedicalNotes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteId { get; set; }
        public required int MedicalRecordId { get; set; }
        public DateTime? DateNote { get; set; }
        public required string NoteType { get; set; }
        public required string NoteName { get; set; }
        [ForeignKey("MedicalRecordId")]
        public MedicalRecords? MedicalRecords { get; set; }
    }
}
