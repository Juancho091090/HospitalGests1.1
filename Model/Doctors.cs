


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalGests.Model
{
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoctorId { get; set; }
        public int IdPerson { get; set; }
        public Persons Persons { get; set; }
        public int SpecialitieId { get; set; }
        public string? Observations { get; set; }
        [ForeignKey("SpecialitieId")]
        public Specialties Specialties { get; set; }
    }
}
