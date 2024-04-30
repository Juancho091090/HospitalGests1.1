
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalGests.Model
{
    public class Patients
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }
        public int IdPerson { get; set; }
        public Persons Person { get; set; }
    }
}
